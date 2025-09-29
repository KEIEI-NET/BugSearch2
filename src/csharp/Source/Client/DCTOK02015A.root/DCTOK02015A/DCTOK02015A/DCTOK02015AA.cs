//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上日報月報
// プログラム概要   ：売上日報月報を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/08/27     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30307 照田 貴志
// 修正日    2009/02/06     修正内容：Mantis【10783】不具合対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/06     修正内容：Mantis【13114】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/05/20     修正内容：Mantis【13309】拠点計の売上目標を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22008 長内
// 修正日    2009/08/11     修正内容：Mantis【14029】　
//                                    日計無し印刷「しない」の場合の累計印字を修正
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：許培珠
// 修 正 日  2012/04/16  　 修正内容：5/24配信分、Redmine#29135
//                                  売上日報月報　達成率・進捗率の計算について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：李亜博
// 修 正 日  2012/05/22  　 修正内容：06/27配信分、Redmine#29898
//                                    売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：李亜博
// 修 正 日  2012/06/07  　 修正内容：06/27配信分、Redmine#30314
//                                    売上日報月報　進捗率の印字が不正
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
    /// 売上日報月報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上日報月報で使用するデータを取得する。</br>
    /// <br>Programmer	: 96186 立花 裕輔</br>
    /// <br>Date		: 2007.09.03</br>
    /// <br>UpdateNote  : 2009/02/06 照田 貴志　不具合対応[10783]</br>
    /// <br>Update Note: 2012/04/16 許培珠</br>
    /// <br>管理番号   ：10801804-00 5/24配信分</br>
    /// <br>             Redmine#29135   売上日報月報　達成率・進捗率の計算について</br>
    /// <br>Update Note : 2012/05/22 李亜博</br>
    /// <br>管理番号    : 10801804-00 06/27配信分</br>
    /// <br>              Redmine#29898   売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
    /// <br>Update Note : 2012/06/07 李亜博</br>
    /// <br>管理番号    : 10801804-00 06/27配信分</br>
    /// <br>              Redmine#30314   売上日報月報　進捗率の印字が不正</br>
    /// </remarks> 
    /// </remarks>
	public class SalesDayMonthReportAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 売上日報月報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上日報月報アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public SalesDayMonthReportAcs()
		{
			this._iSalesDayMonthReportResultDB = (ISalesDayMonthReportResultDB)MediationSalesDayMonthReportResultDB.GetSalesDayMonthReportResultDB();
		}

		/// <summary>
		/// 売上日報月報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上日報月報アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		static SalesDayMonthReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス	
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            // 2008.08.27 30413 犬飼 営業日算出クラスの追加 >>>>>>START
            stc_holidaySettingAcs = new HolidaySettingAcs();
            // 2008.08.27 30413 犬飼 営業日算出クラスの追加 <<<<<<END

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

        // 2008.08.27 30413 犬飼 営業日算出クラスの追加 >>>>>>START
        private static HolidaySettingAcs stc_holidaySettingAcs;
        // 2008.08.27 30413 犬飼 営業日算出クラスの追加 <<<<<<END
        #endregion ■ Static Member

		#region ■ Private Member
		ISalesDayMonthReportResultDB _iSalesDayMonthReportResultDB;

		private DataTable _salesDayMonthReportDt;			// 印刷DataTable
		private DataView _salesDayMonthReportView;	// 印刷DataView

        // ADD 2009/05/20 ------>>>
        // 売上目標取得済拠点リスト
        private List<string> _salesTargetFinSecList;

        // 売上目標アクセス
        private SalesTargetAcs _salesTargetAcs;
        // 年度取得部品
        private DateGetAcs _dateGetAcs;
        // 月度リスト
        List<DateTime> _yearMonthList;
        // 月度開始日リスト
        List<DateTime> _startMonthDateList;
        // 月度締日リスト
        List<DateTime> _endMonthDateList;
        // ADD 2009/05/20 ------<<<
        
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView SalesDayMonthReportView
		{
			get{ return this._salesDayMonthReportView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// 入金データ取得
		/// </summary>
		/// <param name="salesDayMonthReport">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する入金データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public int SearchSalesDayMonthReportProcMain(SalesDayMonthReport salesDayMonthReport, out string errMsg)
		{
			return this.SearchSalesDayMonthReportProc( salesDayMonthReport, out errMsg );
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
		/// <param name="salesDayMonthReport"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private int SearchSalesDayMonthReportProc( SalesDayMonthReport salesDayMonthReport, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCTOK02014EA.CreateDataTable(ref this._salesDayMonthReportDt);
                this._salesTargetFinSecList = new List<string>();   // ADD 2009/05/20

				// 抽出条件展開  --------------------------------------------------------------
				SalesDayMonthReportParamWork salesDayMonthReportParamWork = new SalesDayMonthReportParamWork();
				status = this.DevSalesDayMonthReport(salesDayMonthReport, out salesDayMonthReportParamWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

                // データ取得  ----------------------------------------------------------------
				object salesDayMonthReportDataWork = null;
				status = _iSalesDayMonthReportResultDB.Search(out salesDayMonthReportDataWork, salesDayMonthReportParamWork);

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( salesDayMonthReport, (ArrayList)salesDayMonthReportDataWork );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        // 2008.12.11 30413 犬飼 日計無し印刷のフィルターを追加 >>>>>>START
                        if (this._salesDayMonthReportView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // 2008.12.11 30413 犬飼 日計無し印刷のフィルターを追加 <<<<<<END
                        
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
		/// <param name="salesDayMonthReport">UI抽出条件クラス</param>
		/// <param name="stockMoveListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
		private int DevSalesDayMonthReport ( SalesDayMonthReport salesDayMonthReport, out SalesDayMonthReportParamWork salesDayMonthReportParamWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			salesDayMonthReportParamWork = new SalesDayMonthReportParamWork();
			try
			{
				salesDayMonthReportParamWork.EnterpriseCode = salesDayMonthReport.EnterpriseCode;           // 企業コード
				salesDayMonthReportParamWork.SectionCodes = salesDayMonthReport.SectionCodes;               // 拠点コードリスト
				salesDayMonthReportParamWork.TtlType = salesDayMonthReport.TtlType;                         // 集計方法
				salesDayMonthReportParamWork.SalesDateSt = salesDayMonthReport.SalesDateSt;                 // 開始対象日付(期間)
                salesDayMonthReportParamWork.SalesDateEd = salesDayMonthReport.SalesDateEd;                 // 終了対象日付(期間)
                salesDayMonthReportParamWork.MonthReportDateSt = salesDayMonthReport.MonthReportDateSt;     // 開始対象日付(当月)
                salesDayMonthReportParamWork.MonthReportDateEd = salesDayMonthReport.MonthReportDateEd;     // 終了対象日付(当月)
                // 2008.08.18 30413 犬飼 削除プロパティ >>>>>>START
                //salesDayMonthReportParamWork.MonthReportDateEd = salesDayMonthReport.MonthReportDateEd;
                //salesDayMonthReportParamWork.TargetMonth = salesDayMonthReport.TargetMonth;
                // 2008.08.18 30413 犬飼 削除プロパティ <<<<<<END
                salesDayMonthReportParamWork.CustomerCodeSt = salesDayMonthReport.CustomerCodeSt;           // 開始得意先コード
                // 2008.09.24 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す >>>>>>START
                //salesDayMonthReportParamWork.CustomerCodeEd = salesDayMonthReport.CustomerCodeEd;           // 終了得意先コード
                if (salesDayMonthReport.CustomerCodeEd == 0)
                {
                    // 未入力の場合は、最大値を設定
                    salesDayMonthReportParamWork.CustomerCodeEd = 99999999;
                }
                else
                {
                    salesDayMonthReportParamWork.CustomerCodeEd = salesDayMonthReport.CustomerCodeEd;
                }
                // 2008.09.24 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す <<<<<<END
                
                // 2008.08.18 30413 犬飼 削除プロパティ >>>>>>START
                //salesDayMonthReportParamWork.SalesEmployeeCdSt = salesDayMonthReport.SalesEmployeeCdSt;
                //salesDayMonthReportParamWork.SalesEmployeeCdEd = salesDayMonthReport.SalesEmployeeCdEd;
                //salesDayMonthReportParamWork.SalesEmployeeCdEd = salesDayMonthReport.SalesEmployeeCdEd;
                //salesDayMonthReportParamWork.FrontEmployeeCdSt = salesDayMonthReport.FrontEmployeeCdSt;
                //salesDayMonthReportParamWork.FrontEmployeeCdSt = salesDayMonthReport.FrontEmployeeCdSt;
                //salesDayMonthReportParamWork.FrontEmployeeCdEd = salesDayMonthReport.FrontEmployeeCdEd;
                //salesDayMonthReportParamWork.SalesInputCodeSt = salesDayMonthReport.SalesInputCodeSt;
                //salesDayMonthReportParamWork.SalesInputCodeEd = salesDayMonthReport.SalesInputCodeEd;
                //salesDayMonthReportParamWork.SalesAreaCodeSt = salesDayMonthReport.SalesAreaCodeSt;
                //salesDayMonthReportParamWork.SalesAreaCodeEd = salesDayMonthReport.SalesAreaCodeEd;
                //salesDayMonthReportParamWork.BusinessTypeCodeSt = salesDayMonthReport.BusinessTypeCodeSt;
                //salesDayMonthReportParamWork.BusinessTypeCodeEd = salesDayMonthReport.BusinessTypeCodeEd;
                // 2008.08.18 30413 犬飼 削除プロパティ <<<<<<END
                salesDayMonthReportParamWork.TotalType = salesDayMonthReport.TotalType;                     // 集計単位

                // 2008.08.18 30413 犬飼 追加プロパティ >>>>>>START
                salesDayMonthReportParamWork.SrchCodeSt = salesDayMonthReport.SrchCodeSt;                   // 開始検索コード
                salesDayMonthReportParamWork.SrchCodeEd = salesDayMonthReport.SrchCodeEd;                   // 終了検索コード
                salesDayMonthReportParamWork.OutType = salesDayMonthReport.OutType;                         // 出力順
                // 2008.08.18 30413 犬飼 追加プロパティ <<<<<<END

                // 2009.01.16 30413 犬飼 対象年月(目標期間)を追加 >>>>>>START
                salesDayMonthReportParamWork.TargetYearMonthSt = salesDayMonthReport.TargetYearMonthSt;     // 開始対象年月(目標期間)
                salesDayMonthReportParamWork.TargetYearMonthEd = salesDayMonthReport.TargetYearMonthEd;     // 終了対象年月(目標期間)
                // 2009.01.16 30413 犬飼 対象年月(目標期間)を追加 <<<<<<END
                
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
		/// <param name="salesDayMonthReport">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
        /// <br>UpdateNote : 2012/05/22 李亜博 </br>
        /// <br>管理番号   : 10801804-00 06/27配信分</br>
        /// <br>             Redmine#29898 売上日報月報 進捗率算出時に営業日を参照していないパターンが存在する</br>
        /// <br>Update Note: 2012/06/07 李亜博</br>
        /// <br>管理番号   ：10801614-00 06/27配信分</br>
        /// <br>             Redmine#30314   売上日報月報　進捗率の印字が不正</br>
		/// </remarks>
		private void DevStockMoveData ( SalesDayMonthReport salesDayMonthReport, ArrayList list )
		{
			DataRow dr;

            // DEL 2009/04/06 ------>>>
            //金額単位 1円単位
            Int64 moneyUnit = 1;
            //if(salesDayMonthReport.MoneyUnit == 0)
            //{
            //    moneyUnit = 1;
            //}
            ////金額単位 1000円単位
            //else
            //{
            //    moneyUnit = 1000;
            //}
            // DEL 2009/04/06 ------<<<
			
            // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 >>>>>>START
            Dictionary<string, long> monthSalesTargetMoneyDic = new Dictionary<string, long>();
            // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 <<<<<<END
                    
			foreach ( SalesDayMonthReportResultWork salesDayMonthReportDataWork in list )
			{
                // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 >>>>>>START
                string key = "";
                // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 <<<<<<END

                // 2008.09.02 30413 犬飼 集計単位毎の売上、返品データを一つにまとめる >>>>>>START
                // 集計単位別
                switch (salesDayMonthReport.TotalType)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                        {
                            if ((salesDayMonthReport.OutType == 0) || (salesDayMonthReport.OutType == 3))
                            {
                                // 出力順が「得意先」、「管理拠点」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_CustomerCode + " = '" + salesDayMonthReportDataWork.CustomerCode + "'";
                            }
                            else if (salesDayMonthReport.OutType == 1)
                            {
                                // 出力順が「拠点」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "'";
                            }
                            else
                            {
                                // 出力順が「得意先－拠点」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_CustomerCode + " = '" + salesDayMonthReportDataWork.CustomerCode + "'";
                            }
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                    case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                        {
                            if ((salesDayMonthReport.OutType == 0) || (salesDayMonthReport.OutType == 3))
                            {
                                // 出力順が「担当者(受注者／発行者)」、「管理拠点」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "'";
                            }
                            else if (salesDayMonthReport.OutType == 1)
                            {
                                // 出力順が「得意先」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_CustomerCode + " = '" + salesDayMonthReportDataWork.CustomerCode + "'";

                                // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 >>>>>>START
                                key = salesDayMonthReportDataWork.SectionCode.TrimEnd() + "-" + salesDayMonthReportDataWork.Code.TrimEnd().PadLeft(4, '0');
                                // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 <<<<<<END
                            }
                            else
                            {
                                // 2008.12.11 30413 犬飼 フィルター設定を修正 >>>>>>START
                                // 出力順が「XXX－拠点」
                                //this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                //                                                  + DCTOK02014EA.ct_Col_CustomerCode + " = '" + salesDayMonthReportDataWork.CustomerCode + "'";
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "'";
                                // 2008.12.11 30413 犬飼 フィルター設定を修正 <<<<<<END
                            }
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                        {
                            if (salesDayMonthReport.OutType == 0)
                            {
                                // 出力順が「地区(業種)」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "'";
                            }
                            else if (salesDayMonthReport.OutType == 1)
                            {
                                // 出力順が「得意先」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_CustomerCode + " = '" + salesDayMonthReportDataWork.CustomerCode + "'";
                                // ----- ADD 2012/04/16 xupz for redmine#29135---------->>>>>
                                //拠点コード＋地区コード（業種コード））単位内、１目明細行の売上目標など情報をセットしかない
                                key = salesDayMonthReportDataWork.SectionCode + "-" + salesDayMonthReportDataWork.Code.TrimEnd().PadLeft(4, '0');
                                // ----- ADD 2012/04/16 xupz for redmine#29135----------<<<<<
                            }
                            else
                            {
                                // 2008.12.11 30413 犬飼 フィルター設定を修正 >>>>>>START
                                // 出力順が「XXX－拠点」
                                //this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                //                                                  + DCTOK02014EA.ct_Col_CustomerCode + " = '" + salesDayMonthReportDataWork.CustomerCode + "'";
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "'";
                                // 2008.12.11 30413 犬飼 フィルター設定を修正 <<<<<<END
                            }
                            break;
                        }
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                        {
                            if (salesDayMonthReport.TtlType == 1)
                            {
                                // 集計方法が「拠点毎」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_SectionCode + " = '" + salesDayMonthReportDataWork.SectionCode + "' AND "
                                                                                  + DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "'";
                            }
                            else
                            {
                                // 集計方法が「全社」
                                this._salesDayMonthReportDt.DefaultView.RowFilter = DCTOK02014EA.ct_Col_Code + " = '" + salesDayMonthReportDataWork.Code + "'";
                            }
                            break;
                        }
                        
                }

                if (this._salesDayMonthReportDt.DefaultView.Count == 0)
                {
                    // 新規
                    dr = this._salesDayMonthReportDt.NewRow();
                    // 取得データ展開
                    #region 取得データ展開

                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークとテーブルスキーマの追加 >>>>>>START
                    dr[DCTOK02014EA.ct_Col_Code] = salesDayMonthReportDataWork.Code;                        // XXXコード
                    dr[DCTOK02014EA.ct_Col_Name] = salesDayMonthReportDataWork.Name;                        // XXX名称
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークとテーブルスキーマの追加 <<<<<<END
                    dr[DCTOK02014EA.ct_Col_SectionCode] = salesDayMonthReportDataWork.SectionCode;
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークとテーブルスキーマの変更 >>>>>>START
                    //dr[DCTOK02014EA.ct_Col_SectionGuideNm] = salesDayMonthReportDataWork.SectionGuideNm;
                    //dr[DCTOK02014EA.ct_Col_SubSectionCode] = salesDayMonthReportDataWork.SubSectionCode;
                    //dr[DCTOK02014EA.ct_Col_SubSectionName] = salesDayMonthReportDataWork.SubSectionName;
                    //dr[DCTOK02014EA.ct_Col_MinSectionCode] = salesDayMonthReportDataWork.MinSectionCode;
                    //dr[DCTOK02014EA.ct_Col_MinSectionName] = salesDayMonthReportDataWork.MinSectionName;
                    //dr[DCTOK02014EA.ct_Col_SalesAreaCode] = salesDayMonthReportDataWork.SalesAreaCode;
                    //dr[DCTOK02014EA.ct_Col_SalesAreaName] = salesDayMonthReportDataWork.SalesAreaName;
                    //dr[DCTOK02014EA.ct_Col_BusinessTypeCode] = salesDayMonthReportDataWork.BusinessTypeCode;
                    //dr[DCTOK02014EA.ct_Col_BusinessTypeName] = salesDayMonthReportDataWork.BusinessTypeName;
                    //dr[DCTOK02014EA.ct_Col_SalesEmployeeCd] = salesDayMonthReportDataWork.SalesEmployeeCd;
                    //dr[DCTOK02014EA.ct_Col_SalesEmployeeNm] = salesDayMonthReportDataWork.SalesEmployeeNm;
                    //dr[DCTOK02014EA.ct_Col_FrontEmployeeCd] = salesDayMonthReportDataWork.FrontEmployeeCd;
                    //dr[DCTOK02014EA.ct_Col_FrontEmployeeNm] = salesDayMonthReportDataWork.FrontEmployeeNm;
                    //dr[DCTOK02014EA.ct_Col_SalesInputCode] = salesDayMonthReportDataWork.SalesInputCode;
                    //dr[DCTOK02014EA.ct_Col_SalesInputName] = salesDayMonthReportDataWork.SalesInputName;
                    //dr[DCTOK02014EA.ct_Col_CustomerCode] = salesDayMonthReportDataWork.CustomerCode;
                    //dr[DCTOK02014EA.ct_Col_CustomerName] = salesDayMonthReportDataWork.CustomerName;
                    //dr[DCTOK02014EA.ct_Col_CustomerName2] = salesDayMonthReportDataWork.CustomerName2;
                    dr[DCTOK02014EA.ct_Col_SectionGuideNm] = salesDayMonthReportDataWork.CompanyName1;
                    dr[DCTOK02014EA.ct_Col_CustomerCode] = salesDayMonthReportDataWork.CustomerCode;
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークとテーブルスキーマの変更 <<<<<<END
                    dr[DCTOK02014EA.ct_Col_CustomerSnm] = salesDayMonthReportDataWork.CustomerSnm;
                    dr[DCTOK02014EA.ct_Col_TermSalesSlipCount] = salesDayMonthReportDataWork.TermSalesSlipCount;
                    dr[DCTOK02014EA.ct_Col_TermSalesTotalTaxExc] = salesDayMonthReportDataWork.TermSalesTotalTaxExc / moneyUnit;
                    dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxExc] = salesDayMonthReportDataWork.TermSalesBackTotalTaxExc / moneyUnit;
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 >>>>>>START
                    //dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc] = salesDayMonthReportDataWork.TermSalesDisTtlTaxExc / moneyUnit;
                    dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc] = -(salesDayMonthReportDataWork.TermSalesDisTtlTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_TermTotalCost] = salesDayMonthReportDataWork.TermTotalCost / moneyUnit;
                    dr[DCTOK02014EA.ct_Col_MonthSalesSlipCount] = salesDayMonthReportDataWork.MonthSalesSlipCount;
                    dr[DCTOK02014EA.ct_Col_MonthSalesTotalTaxExc] = salesDayMonthReportDataWork.MonthSalesTotalTaxExc / moneyUnit;
                    dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxExc] = salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc / moneyUnit;
                    //dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc] = salesDayMonthReportDataWork.MonthSalesDisTtlTaxExc / moneyUnit;
                    dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc] = -(salesDayMonthReportDataWork.MonthSalesDisTtlTaxExc / moneyUnit);
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 <<<<<<END
                    dr[DCTOK02014EA.ct_Col_MonthTotalCost] = salesDayMonthReportDataWork.MonthTotalCost / moneyUnit;
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークとテーブルスキーマの変更 >>>>>>START
                    //dr[DCTOK02014EA.ct_Col_SalesTargetMoney] = salesDayMonthReportDataWork.SalesTargetMoney / moneyUnit;
                    //dr[DCTOK02014EA.ct_Col_SalesTargetProfit] = salesDayMonthReportDataWork.SalesTargetProfit / moneyUnit;

                    // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 >>>>>>START
                    //dr[DCTOK02014EA.ct_Col_MonthSalesTargetMoney] = salesDayMonthReportDataWork.MonthSalesTargetMoney / moneyUnit;
                    //dr[DCTOK02014EA.ct_Col_MonthSalesTargetProfit] = salesDayMonthReportDataWork.MonthSalesTargetProfit / moneyUnit;

                    if (key != "")
                    {
                        // キー設定あり
                        if (!monthSalesTargetMoneyDic.ContainsKey(key))
                        {
                            // 該当するキーなし
                            dr[DCTOK02014EA.ct_Col_MonthSalesTargetMoney] = salesDayMonthReportDataWork.MonthSalesTargetMoney / moneyUnit;
                            dr[DCTOK02014EA.ct_Col_MonthSalesTargetProfit] = salesDayMonthReportDataWork.MonthSalesTargetProfit / moneyUnit;
                            monthSalesTargetMoneyDic.Add(key, salesDayMonthReportDataWork.MonthSalesTargetMoney / moneyUnit);
                        }
                        else
                        {
                            // 該当するキーあり
                            dr[DCTOK02014EA.ct_Col_MonthSalesTargetMoney] = 0;
                            dr[DCTOK02014EA.ct_Col_MonthSalesTargetProfit] = 0;
                        }
                    }
                    else
                    {
                        // キー設定なし
                        dr[DCTOK02014EA.ct_Col_MonthSalesTargetMoney] = salesDayMonthReportDataWork.MonthSalesTargetMoney / moneyUnit;
                        dr[DCTOK02014EA.ct_Col_MonthSalesTargetProfit] = salesDayMonthReportDataWork.MonthSalesTargetProfit / moneyUnit;
                    }
                    // 2009.01.20 30413 犬飼 担当者／受注者／発行者の得意先順時の目標関連項目の処理を追加 <<<<<<END
                    
                    //dr[DCTOK02014EA.ct_Col_TermSalesNetPrice] = salesDayMonthReportDataWork.TermSalesNetPrice / moneyUnit;			//期間売上正価金額
                    //dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] = salesDayMonthReportDataWork.TermSalesBackNetPrice / moneyUnit;	//期間返品正価金額	
                    //dr[DCTOK02014EA.ct_Col_MonthSalesNetPrice] = salesDayMonthReportDataWork.MonthSalesNetPrice / moneyUnit;		//月次売上正価金額
                    //dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] = salesDayMonthReportDataWork.MonthSalesBackNetPrice / moneyUnit;//月次返品正価金額
                    dr[DCTOK02014EA.ct_Col_TermSalesNetPrice] = salesDayMonthReportDataWork.TermSalesTotalTaxExc / moneyUnit;			//期間売上正価金額
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 >>>>>>START
                    //dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] = salesDayMonthReportDataWork.TermSalesBackTotalTaxExc / moneyUnit;	//期間返品正価金額	
                    dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] = -(salesDayMonthReportDataWork.TermSalesBackTotalTaxExc / moneyUnit);	//期間返品正価金額	
                    dr[DCTOK02014EA.ct_Col_MonthSalesNetPrice] = salesDayMonthReportDataWork.MonthSalesTotalTaxExc / moneyUnit;		//月次売上正価金額
                    //dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] = salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc / moneyUnit;//月次返品正価金額
                    dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] = -(salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc / moneyUnit);//月次返品正価金額
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 <<<<<<END
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークとテーブルスキーマの変更 <<<<<<END

                    // 2008.08.28 30413 犬飼 自拠点の当月営業日数と対象営業日数を取得 >>>>>>START
                    int workDays = 0;
                    int progress = 0;
                    stc_holidaySettingAcs.GetWorkDaysInMonth(stc_Employee.BelongSectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                    dr[DCTOK02014EA.ct_Col_SelfSectionWorkDays] = workDays;
                    dr[DCTOK02014EA.ct_Col_SelfSectionProgressDays] = progress;
                    // 2008.08.28 30413 犬飼 自拠点の当月営業日数と対象営業日数を取得 <<<<<<END

                    // 2008.08.27 30413 犬飼 当月営業日数と対象営業日数を取得 >>>>>>START
                    // 月度の総営業日数取得処理
                    workDays = 0;
                    progress = 0;
                    //stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionCode, salesDayMonthReport.MonthReportDateEd, out workDays, out progress);

                    // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
                     //全社
                    if ((int)salesDayMonthReport.TtlType == 0)
                    {
                        switch ((int)salesDayMonthReport.TotalType)
                        {
                            case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                                {
                                    if (salesDayMonthReport.OutType != 1)
                                    {
                                        // 出力順 !=「拠点」
                                        stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionMngCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    }
                                    else
                                    {
                                        // 出力順が「拠点」
                                        stc_holidaySettingAcs.GetWorkDaysInMonth(stc_Employee.BelongSectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    }
                                    break;
                                }
                            case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                            case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                            case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                                {
                                    // 担当者/受注者別/発行者別の所属拠点の営業日                         
                                    if (salesDayMonthReport.OutType != 1)
                                    {
                                        // 出力順 !=「得意先」
                                        stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionMngCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    }
                                    else
                                    {
                                        //出力順が「得意先」
                                        stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    }
                                    break;
                                }
                            case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                            case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                                {
                                    // ログイン拠点の営業日
                                    if (salesDayMonthReport.OutType != 1)
                                    {
                                        // 出力順 !=「得意先」
                                        stc_holidaySettingAcs.GetWorkDaysInMonth(stc_Employee.BelongSectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    }
                                    else
                                    {
                                        //出力順が「得意先」
                                        stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    }
                                    break;
                                }
                            case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                                {
                                    stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                    }
                    // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    //stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress); //DEL 2012/05/22 李亜博 Redmine#29898
                    dr[DCTOK02014EA.ct_Col_WorkDays] = workDays;
                    dr[DCTOK02014EA.ct_Col_ProgressDays] = progress;
                    // 2008.08.27 30413 犬飼 当月営業日数と対象営業日数を取得 <<<<<<END

                    // --------------- ADD START 2012/05/22 Redmine#29898 李亜博-------->>>>
                    //管理拠点の当月営業日数と対象営業日数を取得
                    workDays = 0;
                    progress = 0;
                    stc_holidaySettingAcs.GetWorkDaysInMonth(salesDayMonthReportDataWork.SectionMngCode.Trim(), salesDayMonthReport.MonthReportDateEd, out workDays, out progress);
                    dr[DCTOK02014EA.ct_Col_MngSectionWorkDays] = workDays;
                    dr[DCTOK02014EA.ct_Col_MngSectionProgressDays] = progress;
                    // --------------- ADD END 2012/05/22 Redmine#29898 李亜博--------<<<<
                    
                    //期間純売上額
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 >>>>>>START
                    //Int64 termPureSalesTotalCost = salesDayMonthReportDataWork.TermSalesNetPrice
                    //                            + salesDayMonthReportDataWork.TermSalesBackNetPrice
                    //                            + salesDayMonthReportDataWork.TermSalesDisTtlTaxExc;
                    Int64 termPureSalesTotalCost = salesDayMonthReportDataWork.TermSalesTotalTaxExc
                                                + salesDayMonthReportDataWork.TermSalesBackTotalTaxExc
                                                + salesDayMonthReportDataWork.TermSalesDisTtlTaxExc;
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 <<<<<<END
                    dr[DCTOK02014EA.ct_Col_TermPureSalesTotalCost] = termPureSalesTotalCost / moneyUnit;

                    //月次純売上額
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 >>>>>>START
                    //Int64 monthPureSalesTotalCost = salesDayMonthReportDataWork.MonthSalesNetPrice
                    //                            + salesDayMonthReportDataWork.MonthSalesBackNetPrice
                    //                            + salesDayMonthReportDataWork.MonthSalesDisTtlTaxExc;
                    Int64 monthPureSalesTotalCost = salesDayMonthReportDataWork.MonthSalesTotalTaxExc
                                                + salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc
                                                + salesDayMonthReportDataWork.MonthSalesDisTtlTaxExc;
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 <<<<<<END
                    dr[DCTOK02014EA.ct_Col_MonthPureSalesTotalCost] = monthPureSalesTotalCost / moneyUnit;

                    //期間返品率
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 >>>>>>START
                    //if (salesDayMonthReportDataWork.TermSalesNetPrice == 0)
                    if (salesDayMonthReportDataWork.TermSalesTotalTaxExc == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxRate] = 0;
                    }
                    else
                    {
                        //dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxRate] = Math.Abs(((double)salesDayMonthReportDataWork.TermSalesBackNetPrice * 100
                        //    / (double)salesDayMonthReportDataWork.TermSalesNetPrice));
                        dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxRate] = Math.Abs(((double)salesDayMonthReportDataWork.TermSalesBackTotalTaxExc * 100
                            / (double)salesDayMonthReportDataWork.TermSalesTotalTaxExc));
                    }
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 <<<<<<END

                    //月次返品率
                    if (salesDayMonthReportDataWork.MonthSalesTotalTaxExc == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxRate] = 0;
                    }
                    else
                    {
                        // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 >>>>>>START
                        //dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxRate] = Math.Abs(((double)salesDayMonthReportDataWork.MonthSalesBackNetPrice * 100
                        //    / (double)salesDayMonthReportDataWork.MonthSalesNetPrice));
                        dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxRate] = Math.Abs(((double)salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc * 100
                            / (double)salesDayMonthReportDataWork.MonthSalesTotalTaxExc));
                        // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 <<<<<<END
                    }

                    // 2008.08.19 30413 犬飼 テーブルスキーマの追加 >>>>>>START
                    // 月次売上進捗率
                    if (salesDayMonthReportDataWork.MonthSalesTargetMoney == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = 0;
                    }
                    else
                    {
                        // 2009.01.20 30413 犬飼 浮動小数点に合わせた計算に修正 >>>>>>START
                        //double progressTargetMoney = salesDayMonthReportDataWork.MonthSalesTargetMoney / (Int32)dr[DCTOK02014EA.ct_Col_WorkDays] * (Int32)dr[DCTOK02014EA.ct_Col_ProgressDays];
                        // double progressTargetMoney = (double)salesDayMonthReportDataWork.MonthSalesTargetMoney / double.Parse(dr[DCTOK02014EA.ct_Col_WorkDays].ToString()) * double.Parse(dr[DCTOK02014EA.ct_Col_ProgressDays].ToString());//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        double progressTargetMoney;
                        if (double.Parse(dr[DCTOK02014EA.ct_Col_WorkDays].ToString()) == 0 || double.Parse(dr[DCTOK02014EA.ct_Col_ProgressDays].ToString())==0)
                        {
                             progressTargetMoney = 0;
                        }
                        else
                        {
                             progressTargetMoney = (double)salesDayMonthReportDataWork.MonthSalesTargetMoney / double.Parse(dr[DCTOK02014EA.ct_Col_WorkDays].ToString()) * double.Parse(dr[DCTOK02014EA.ct_Col_ProgressDays].ToString());
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                        // 2009.01.20 30413 犬飼 浮動小数点に合わせた計算に修正 <<<<<<END
                        //dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = (double)monthPureSalesTotalCost / progressTargetMoney * 100;//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        if (progressTargetMoney == 0)
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = 0;
                        }
                        else
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = (double)monthPureSalesTotalCost / progressTargetMoney * 100;
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                    }
                    // 2008.08.19 30413 犬飼 テーブルスキーマの追加 <<<<<<END

                    //月次売上達成率
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 >>>>>>START
                    //if (salesDayMonthReportDataWork.SalesTargetMoney == 0)
                    if (salesDayMonthReportDataWork.MonthSalesTargetMoney == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthTargetSalesRate] = 0;
                    }
                    else
                    {
                        //dr[DCTOK02014EA.ct_Col_MonthTargetSalesRate] = ((double)monthPureSalesTotalCost * 100
                        //    / (double)salesDayMonthReportDataWork.SalesTargetMoney);
                        dr[DCTOK02014EA.ct_Col_MonthTargetSalesRate] = ((double)monthPureSalesTotalCost * 100
                            / (double)salesDayMonthReportDataWork.MonthSalesTargetMoney);
                    }
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 <<<<<<END

                    // 2008.12.08 30413 犬飼 リモート修正に合わせて粗利益の計算を変更 >>>>>>START
                    //期間粗利益
                    //Int64 termProfit = (salesDayMonthReportDataWork.TermSalesTotalTaxExc
                    //                + salesDayMonthReportDataWork.TermSalesBackTotalTaxExc
                    //                - salesDayMonthReportDataWork.TermTotalCost);
                    // 期間純売上額-期間原価金額
                    Int64 termProfit = termPureSalesTotalCost - salesDayMonthReportDataWork.TermTotalCost;
                                    
                    dr[DCTOK02014EA.ct_Col_TermProfit] = termProfit / moneyUnit;

                    //月次粗利益
                    //Int64 monthProfit = (salesDayMonthReportDataWork.MonthSalesTotalTaxExc
                    //                + salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc
                    //                - salesDayMonthReportDataWork.MonthTotalCost);
                    // 月次純売上額-月次原価金額
                    Int64 monthProfit = monthPureSalesTotalCost - salesDayMonthReportDataWork.MonthTotalCost;
                                    
                    dr[DCTOK02014EA.ct_Col_MonthProfit] = monthProfit / moneyUnit;
                    // 2008.12.08 30413 犬飼 リモート修正に合わせて粗利益の計算を変更 <<<<<<END                    

                    //期間粗利率
                    if (termPureSalesTotalCost == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_TermProfitRate] = 0;
                    }
                    else
                    {
                        dr[DCTOK02014EA.ct_Col_TermProfitRate] = ((double)termProfit * 100
                            / (double)termPureSalesTotalCost);
                    }

                    //月次粗利率
                    if (monthPureSalesTotalCost == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProfitRate] = 0;
                    }
                    else
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProfitRate] = ((double)monthProfit * 100
                            / (double)monthPureSalesTotalCost);
                    }

                    // 2008.08.19 30413 犬飼 テーブルスキーマの追加 >>>>>>START
                    // 月次粗利進捗率
                    if (salesDayMonthReportDataWork.MonthSalesTargetProfit == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = 0;
                    }
                    else
                    {
                        // 2009.01.20 30413 犬飼 浮動小数点に合わせた計算に修正 >>>>>>START
                        //double progressTargetProfit = salesDayMonthReportDataWork.MonthSalesTargetProfit / (Int32)dr[DCTOK02014EA.ct_Col_WorkDays] * (Int32)dr[DCTOK02014EA.ct_Col_ProgressDays];
                        //double progressTargetProfit = (double)salesDayMonthReportDataWork.MonthSalesTargetProfit / double.Parse(dr[DCTOK02014EA.ct_Col_WorkDays].ToString()) * double.Parse(dr[DCTOK02014EA.ct_Col_ProgressDays].ToString());//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        double progressTargetProfit;
                        if (double.Parse(dr[DCTOK02014EA.ct_Col_WorkDays].ToString()) == 0 || double.Parse(dr[DCTOK02014EA.ct_Col_ProgressDays].ToString()) == 0)
                        {
                             progressTargetProfit = 0;
                        }
                        else
                        {
                             progressTargetProfit = (double)salesDayMonthReportDataWork.MonthSalesTargetProfit / double.Parse(dr[DCTOK02014EA.ct_Col_WorkDays].ToString()) * double.Parse(dr[DCTOK02014EA.ct_Col_ProgressDays].ToString());
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                        // 2009.01.20 30413 犬飼 浮動小数点に合わせた計算に修正 <<<<<<END
                        //dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = (double)monthProfit / progressTargetProfit * 100;//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        if (progressTargetProfit == 0)
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = 0;
                        }
                        else
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = (double)monthProfit / progressTargetProfit * 100;
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                    }
                    // 2008.08.19 30413 犬飼 テーブルスキーマの追加 <<<<<<END

                    //月次粗利達成率
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 >>>>>>START
                    //if (salesDayMonthReportDataWork.SalesTargetProfit == 0)
                    if (salesDayMonthReportDataWork.MonthSalesTargetProfit == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthTargetProfitRate] = 0;
                    }
                    else
                    {
                        //dr[DCTOK02014EA.ct_Col_MonthTargetProfitRate] = ((double)monthProfit * 100
                        //    / (double)salesDayMonthReportDataWork.SalesTargetProfit);
                        dr[DCTOK02014EA.ct_Col_MonthTargetProfitRate] = ((double)monthProfit * 100
                            / (double)salesDayMonthReportDataWork.MonthSalesTargetProfit);
                    }
                    // 2008.08.19 30413 犬飼 売上日報月報抽出ワークの取得プロパティ変更 <<<<<<END

                    // 2008.08.26 30413 犬飼 集計単位の値が変わったので削除 >>>>>>START
                    //集計方法が営業所毎で集計単位が0:拠点別の場合
                    //string sectionHeaderField = "";
                    //if ((salesDayMonthReport.TtlType == 1) || (salesDayMonthReport.TotalType == 0))
                    //{
                    //    sectionHeaderField = salesDayMonthReportDataWork.SectionCode;
                    //}
                    // 2008.08.26 30413 犬飼 集計単位の値が変わったので削除 <<<<<<END

                    // 2008.08.19 30413 犬飼 出力単位別の帳票設定を変更 >>>>>>START
                    ////0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
                    //switch (salesDayMonthReport.TotalType)
                    //{
                    //    //0:拠点別
                    //    case 0:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        break;
                    //    //1:部署別
                    //    case 1:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.SubSectionCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SubSectionCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.SubSectionName;
                    //        break;
                    //    //2:課別
                    //    case 2:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = salesDayMonthReportDataWork.SubSectionCode;
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.MinSectionCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = salesDayMonthReportDataWork.SubSectionCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = salesDayMonthReportDataWork.SubSectionName;
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.MinSectionCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.MinSectionName;
                    //        break;
                    //    //3:地区別
                    //    case 3:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.SalesAreaCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SalesAreaCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.SalesAreaName;
                    //        break;
                    //    //4:業種別
                    //    case 4:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.BusinessTypeCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.BusinessTypeCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.BusinessTypeName;
                    //        break;
                    //    //5:担当者別
                    //    case 5:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.SalesEmployeeCd;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SalesEmployeeCd;
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.SalesEmployeeNm;
                    //        break;
                    //    //6:受注者別
                    //    case 6:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.FrontEmployeeCd;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.FrontEmployeeCd;
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.FrontEmployeeNm;
                    //        break;
                    //    //7:発行者別
                    //    case 7:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.SalesInputCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SalesInputCode;
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.SalesInputName;
                    //        break;

                    //    //8:得意先別
                    //    case 8:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.CustomerCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.CustomerCode.ToString("d9");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerName;
                    //        break;
                    //    //9:地区別得意先別
                    //    case 9:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = salesDayMonthReportDataWork.SalesAreaCode;
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.CustomerCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = salesDayMonthReportDataWork.SalesAreaCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = salesDayMonthReportDataWork.SalesAreaName;
                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.CustomerCode.ToString("d9");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerName;
                    //        break;

                    //    //10:業種別得意先別意
                    //    case 10:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = salesDayMonthReportDataWork.BusinessTypeCode;
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.CustomerCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = salesDayMonthReportDataWork.BusinessTypeCode.ToString("d2");
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = salesDayMonthReportDataWork.BusinessTypeName;

                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.CustomerCode.ToString("d9");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerName;
                    //        break;
                    //    // 11:担当者別得意先別
                    //    case 11:
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = salesDayMonthReportDataWork.SalesEmployeeCd;
                    //        dr[DCTOK02014EA.ct_Col_DailyHeaderField] = salesDayMonthReportDataWork.CustomerCode;

                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                    //        dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.SectionGuideNm;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = salesDayMonthReportDataWork.SalesEmployeeCd;
                    //        dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = salesDayMonthReportDataWork.SalesEmployeeNm;

                    //        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.CustomerCode.ToString("d9");
                    //        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerName;
                    //        break;
                    //}

                    // 2008.09.24 30413 犬飼 0埋め等の加工を一箇所で行う >>>>>>START
                    string padCustomerCode = salesDayMonthReportDataWork.CustomerCode.ToString("d08");  // 得意先コード
                    string padCode = salesDayMonthReportDataWork.Code.TrimEnd().PadLeft(4, '0');        // 集計単位別コード
                    string rmName = salesDayMonthReportDataWork.Name;                                   // 集計単位別名称

                    // ---ADD 2009/02/06 不具合対応[10783] ------------------------------------------------------------->>>>>
                    dr[DCTOK02014EA.ct_Col_SortSectionCode] = salesDayMonthReportDataWork.SectionCode;                      //ソート用拠点
                    dr[DCTOK02014EA.ct_Col_SortCustomerCode] = salesDayMonthReportDataWork.CustomerCode.ToString("d08");    //ソート用得意先
                    dr[DCTOK02014EA.ct_Col_SortCode] = salesDayMonthReportDataWork.Code.TrimEnd().PadLeft(4, '0');          //ソート用汎用コード
                    // ---ADD 2009/02/06 不具合対応[10783] -------------------------------------------------------------<<<<<

                    if (rmName.Length > 10)
                    {
                        // 10桁以上の集計単位別名称はカット
                        rmName = rmName.Remove(10);
                    }
                    // 2008.09.24 30413 犬飼 0埋め等の加工を一箇所で行う <<<<<<END
                    
                    // 集計単位別
                    switch (salesDayMonthReport.TotalType)
                    {
                        case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                            {
                                if ((salesDayMonthReport.OutType == 0) || (salesDayMonthReport.OutType == 3))
                                {
                                    // 出力順が「得意先」、「管理拠点」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCustomerCode;   // 得意先コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerSnm;
                                }
                                else if (salesDayMonthReport.OutType == 1)
                                {
                                    // 出力順が「拠点」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                }
                                else
                                {
                                    // 出力順が「得意先－拠点」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = padCustomerCode;   // 得意先コード

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLine] = padCustomerCode;   // 得意先コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLineName] = salesDayMonthReportDataWork.CustomerSnm;

                                    // 2008.12.12 30413 犬飼 集計方法によって明細部のコードと名称の設定を変更 >>>>>>START
                                    //dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                    //dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    if (salesDayMonthReport.TtlType == 0)
                                    {
                                        // 集計方法が全社
                                        dr[DCTOK02014EA.ct_Col_DetailLine] = padCustomerCode;   // 得意先コード
                                        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerSnm;
                                    }
                                    else
                                    {
                                        // 集計方法が拠点毎
                                        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    }
                                    // 2008.12.12 30413 犬飼 集計方法によって明細部のコードと名称の設定を変更 <<<<<<END
                                }
                                break;
                            }
                        case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                        case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                        case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                            {
                                if ((salesDayMonthReport.OutType == 0) || (salesDayMonthReport.OutType == 3))
                                {
                                    // 出力順が「担当者(受注者／発行者)」、「管理拠点」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = rmName;    // 集計単位別名称
                                }
                                else if (salesDayMonthReport.OutType == 1)
                                {
                                    // 出力順が「得意先」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderTypeLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderTypeLineName] = rmName;    // 集計単位別名称;
                                    // 2008.12.09 30413 犬飼 集計方法が全社時の印字対応 >>>>>>START
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLineName] = rmName;    // 集計単位別名称;
                                    // 2008.12.09 30413 犬飼 集計方法が全社時の印字対応 <<<<<<END
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCustomerCode;   // 得意先コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerSnm;
                                }
                                else
                                {
                                    // 出力順が「XXX－拠点」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = padCode;       // 集計単位別コード

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLineName] = rmName;    // 集計単位別名称;

                                    // 2008.12.12 30413 犬飼 集計方法によって明細部のコードと名称の設定を変更 >>>>>>START
                                    //dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                    //dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    if (salesDayMonthReport.TtlType == 0)
                                    {
                                        // 集計方法が全社
                                        dr[DCTOK02014EA.ct_Col_DetailLine] = padCode;       // 集計単位別コード
                                        dr[DCTOK02014EA.ct_Col_DetailLineName] = rmName;    // 集計単位別名称;
                                    }
                                    else
                                    {
                                        // 集計方法が拠点毎
                                        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    }
                                    // 2008.12.12 30413 犬飼 集計方法によって明細部のコードと名称の設定を変更 <<<<<<END
                                }
                                break;
                            }
                        case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                        case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                            {
                                if ((salesDayMonthReport.OutType == 0))
                                {
                                    // 出力順が「地区(業種)」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = rmName;    // 集計単位別名称;
                                }
                                else if (salesDayMonthReport.OutType == 1)
                                {
                                    // 出力順が「得意先」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderTypeLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderTypeLineName] = rmName;    // 集計単位別名称;
                                    // 2008.12.09 30413 犬飼 集計方法が全社時の印字対応 >>>>>>START
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLineName] = rmName;    // 集計単位別名称;
                                    // 2008.12.09 30413 犬飼 集計方法が全社時の印字対応 <<<<<<END
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCustomerCode;   // 得意先コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CustomerSnm;
                                }
                                else
                                {
                                    // 出力順が「XXX－拠点」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = padCode;       // 集計単位別コード

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderLineName] = rmName;    // 集計単位別名称;

                                    // 2008.12.12 30413 犬飼 集計方法によって明細部のコードと名称の設定を変更 >>>>>>START
                                    //dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                    //dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    if (salesDayMonthReport.TtlType == 0)
                                    {
                                        // 集計方法が全社
                                        dr[DCTOK02014EA.ct_Col_DetailLine] = padCode;       // 集計単位別コード
                                        dr[DCTOK02014EA.ct_Col_DetailLineName] = rmName;    // 集計単位別名称;
                                    }
                                    else
                                    {
                                        // 集計方法が拠点毎
                                        dr[DCTOK02014EA.ct_Col_DetailLine] = salesDayMonthReportDataWork.SectionCode;
                                        dr[DCTOK02014EA.ct_Col_DetailLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    }
                                    // 2008.12.12 30413 犬飼 集計方法によって明細部のコードと名称の設定を変更 <<<<<<END
                                }
                                break;
                            }
                        case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:              // 販売区分
                            {
                                if (salesDayMonthReport.TtlType == 1)
                                {
                                    // 集計方法が「拠点毎」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = salesDayMonthReportDataWork.SectionCode;
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = salesDayMonthReportDataWork.CompanyName1;
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = rmName;    // 集計単位別名称;
                                }
                                else
                                {
                                    // 集計方法が「全社」
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderField] = "";
                                    dr[DCTOK02014EA.ct_Col_DailyHeaderField] = "";

                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_SectionHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLine] = "";
                                    dr[DCTOK02014EA.ct_Col_WareHouseHeaderLineName] = "";
                                    dr[DCTOK02014EA.ct_Col_DetailLine] = padCode;       // 集計単位別コード
                                    dr[DCTOK02014EA.ct_Col_DetailLineName] = rmName;    // 集計単位別名称;
                                }
                                break;
                            }
                    }
                    // 2008.08.19 30413 犬飼 出力単位別の帳票設定を変更 <<<<<<END

                    #endregion

                    // ADD 2009/05/20 ------>>>
                    // 売上目標(拠点計用)取得
                    this.GetSalesTarget(salesDayMonthReport, salesDayMonthReportDataWork.SectionCode, ref dr);
                    // ADD 2009/05/20 ------<<<

                    // TableにAdd
                    this._salesDayMonthReportDt.Rows.Add(dr);
                }
                else
                {
                    // 既にデータが存在してる場合
                    this._salesDayMonthReportDt.BeginLoadData();
                    dr = this._salesDayMonthReportDt.DefaultView[0].Row;

                    dr[DCTOK02014EA.ct_Col_TermSalesSlipCount] = (Int32)dr[DCTOK02014EA.ct_Col_TermSalesSlipCount] + salesDayMonthReportDataWork.TermSalesSlipCount;
                    dr[DCTOK02014EA.ct_Col_TermSalesTotalTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesTotalTaxExc] + (salesDayMonthReportDataWork.TermSalesTotalTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxExc] + (salesDayMonthReportDataWork.TermSalesBackTotalTaxExc / moneyUnit);
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 >>>>>>START
                    //dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc] + (salesDayMonthReportDataWork.TermSalesDisTtlTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc] - (salesDayMonthReportDataWork.TermSalesDisTtlTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_TermTotalCost] = (Int64)dr[DCTOK02014EA.ct_Col_TermTotalCost] + (salesDayMonthReportDataWork.TermTotalCost / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_MonthSalesSlipCount] = (Int32)dr[DCTOK02014EA.ct_Col_MonthSalesSlipCount] + (salesDayMonthReportDataWork.MonthSalesSlipCount);
                    dr[DCTOK02014EA.ct_Col_MonthSalesTotalTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesTotalTaxExc] + (salesDayMonthReportDataWork.MonthSalesTotalTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxExc] + (salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc / moneyUnit);
                    //dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc] + (salesDayMonthReportDataWork.MonthSalesDisTtlTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc] - (salesDayMonthReportDataWork.MonthSalesDisTtlTaxExc / moneyUnit);
                    dr[DCTOK02014EA.ct_Col_MonthTotalCost] = (Int64)dr[DCTOK02014EA.ct_Col_MonthTotalCost] + (salesDayMonthReportDataWork.MonthTotalCost / moneyUnit);

                    dr[DCTOK02014EA.ct_Col_TermSalesNetPrice] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesNetPrice] + (salesDayMonthReportDataWork.TermSalesTotalTaxExc / moneyUnit);			//期間売上正価金額
                    //dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] + (salesDayMonthReportDataWork.TermSalesBackTotalTaxExc / moneyUnit);	//期間返品正価金額	
                    dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesBackNetPrice] - (salesDayMonthReportDataWork.TermSalesBackTotalTaxExc / moneyUnit);	//期間返品正価金額	
                    dr[DCTOK02014EA.ct_Col_MonthSalesNetPrice] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesNetPrice] + (salesDayMonthReportDataWork.MonthSalesTotalTaxExc / moneyUnit);		//月次売上正価金額
                    //dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] + (salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc / moneyUnit);//月次返品正価金額
                    dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesBackNetPrice] - (salesDayMonthReportDataWork.MonthSalesBackTotalTaxExc / moneyUnit);//月次返品正価金額
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 <<<<<<END
                    
                    long termSalesTotalTaxExc = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesTotalTaxExc];
                    long termSalesBackTotalTaxExc = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxExc];
                    long termSalesDisTtlTaxExc = (Int64)dr[DCTOK02014EA.ct_Col_TermSalesDisTtlTaxExc];
                    long termTotalCost = (Int64)dr[DCTOK02014EA.ct_Col_TermTotalCost];

                    long monthSalesTotalTaxExc = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesTotalTaxExc];
                    long monthSalesBackTotalTaxExc = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxExc];
                    long monthSalesDisTtlTaxExc = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesDisTtlTaxExc];
                    long monthTotalCost = (Int64)dr[DCTOK02014EA.ct_Col_MonthTotalCost];

                    long monthSalesTargetMoney = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesTargetMoney];
                    long monthSalesTargetProfit = (Int64)dr[DCTOK02014EA.ct_Col_MonthSalesTargetProfit];

                    int workDays = (Int32)dr[DCTOK02014EA.ct_Col_WorkDays];
                    int progressDays = (Int32)dr[DCTOK02014EA.ct_Col_ProgressDays];

                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 >>>>>>START
                    //期間純売上額
                    Int64 termPureSalesTotalCost = termSalesTotalTaxExc
                                                + termSalesBackTotalTaxExc
                                                //+ termSalesDisTtlTaxExc;
                                                - termSalesDisTtlTaxExc;
                    dr[DCTOK02014EA.ct_Col_TermPureSalesTotalCost] = termPureSalesTotalCost / moneyUnit;

                    //月次純売上額
                    Int64 monthPureSalesTotalCost = monthSalesTotalTaxExc
                                                + monthSalesBackTotalTaxExc
                                                //+ monthSalesDisTtlTaxExc;
                                                - monthSalesDisTtlTaxExc;
                    dr[DCTOK02014EA.ct_Col_MonthPureSalesTotalCost] = monthPureSalesTotalCost / moneyUnit;
                    // 2009.02.12 30413 犬飼 返品と値引の符号を反転 <<<<<<END
                    
                    //期間返品率
                    if (termSalesTotalTaxExc == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxRate] = 0;
                    }
                    else
                    {
                        dr[DCTOK02014EA.ct_Col_TermSalesBackTotalTaxRate] = Math.Abs(((double)termSalesBackTotalTaxExc * 100
                            / (double)termSalesTotalTaxExc));
                    }

                    //月次返品率
                    if (monthSalesTotalTaxExc == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxRate] = 0;
                    }
                    else
                    {
                        dr[DCTOK02014EA.ct_Col_MonthSalesBackTotalTaxRate] = Math.Abs(((double)monthSalesBackTotalTaxExc * 100
                            / (double)monthSalesTotalTaxExc));
                    }

                    // 月次売上進捗率
                    // 月次売上達成率
                    if (monthSalesTargetMoney == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = 0;
                        dr[DCTOK02014EA.ct_Col_MonthTargetSalesRate] = 0;
                    }
                    else
                    {
                        //double progressTargetMoney = (double)monthSalesTargetMoney / (double)workDays * (double)progressDays;//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        double progressTargetMoney;
                        if ((double)workDays==0 || (double)progressDays==0)
                        {
                            progressTargetMoney = 0;
                        }
                        else
                        {
                             progressTargetMoney = (double)monthSalesTargetMoney / (double)workDays * (double)progressDays;
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                        //dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = (double)monthPureSalesTotalCost / progressTargetMoney * 100;//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        if (progressTargetMoney == 0)
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = 0;
                        }
                        else
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressSalesRate] = (double)monthPureSalesTotalCost / progressTargetMoney * 100;
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                        dr[DCTOK02014EA.ct_Col_MonthTargetSalesRate] = ((double)monthPureSalesTotalCost * 100
                            / (double)monthSalesTargetMoney);
                    }

                    // 2008.12.08 30413 犬飼 リモート修正に合わせて粗利益の計算を変更 >>>>>>START
                    //期間粗利益
                    //Int64 termProfit = (termSalesTotalTaxExc
                    //                + termSalesBackTotalTaxExc
                    //                - termTotalCost);
                    // 期間純売上額-期間原価金額
                    Int64 termProfit = termPureSalesTotalCost - termTotalCost;

                    dr[DCTOK02014EA.ct_Col_TermProfit] = termProfit / moneyUnit;

                    //月次粗利益
                    //Int64 monthProfit = (monthSalesTotalTaxExc
                    //                + monthSalesBackTotalTaxExc
                    //                - monthTotalCost);
                    // 月次純売上額-月次原価金額
                    Int64 monthProfit = monthPureSalesTotalCost - monthTotalCost;

                    dr[DCTOK02014EA.ct_Col_MonthProfit] = monthProfit / moneyUnit;
                    // 2008.12.08 30413 犬飼 リモート修正に合わせて粗利益の計算を変更 <<<<<<END                    

                    //期間粗利率
                    if (termPureSalesTotalCost == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_TermProfitRate] = 0;
                    }
                    else
                    {
                        dr[DCTOK02014EA.ct_Col_TermProfitRate] = ((double)termProfit * 100
                            / (double)termPureSalesTotalCost);
                    }

                    //月次粗利率
                    if (monthPureSalesTotalCost == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProfitRate] = 0;
                    }
                    else
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProfitRate] = ((double)monthProfit * 100
                            / (double)monthPureSalesTotalCost);
                    }

                    // 月次粗利進捗率
                    // 月次粗利達成率
                    if (monthSalesTargetProfit == 0)
                    {
                        dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = 0;
                        dr[DCTOK02014EA.ct_Col_MonthTargetProfitRate] = 0;
                    }
                    else
                    {
                        //double progressTargetProfit = (double)monthSalesTargetProfit / (double)workDays * (double)progressDays;//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        double progressTargetProfit;
                        if ((double)workDays==0 || (double)progressDays == 0)
                        {
                            progressTargetProfit = 0;
                        }
                        else
                        {
                             progressTargetProfit = (double)monthSalesTargetProfit / (double)workDays * (double)progressDays;
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                        //dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = (double)monthProfit / progressTargetProfit * 100;//DEL  李亜博 2012/06/07  Redmine#30314
                        // --------------- ADD START 2012/06/07 Redmine#30314 李亜博-------->>>>
                        if (progressTargetProfit == 0)
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = 0;
                        }
                        else
                        {
                            dr[DCTOK02014EA.ct_Col_MonthProgressProfitRate] = (double)monthProfit / progressTargetProfit * 100;
                        }
                        // --------------- ADD END 2012/06/07 Redmine#30314 李亜博--------<<<<
                        dr[DCTOK02014EA.ct_Col_MonthTargetProfitRate] = ((double)monthProfit * 100
                            / (double)monthSalesTargetProfit);
                    }

                    // ADD 2009/05/20 ------>>>
                    // 売上目標(拠点計用)取得
                    this.GetSalesTarget(salesDayMonthReport, salesDayMonthReportDataWork.SectionCode, ref dr);
                    // ADD 2009/05/20 ------<<<

                    this._salesDayMonthReportDt.EndLoadData();                    
                }
			}
            // 2008.09.02 30413 犬飼 集計単位毎の売上、返品データを一つにまとめる <<<<<<END

            // 2008.12.11 30413 犬飼 日計無し印刷のフィルターを追加 >>>>>>START
            // DataView作成
            //this._salesDayMonthReportView = new DataView( this._salesDayMonthReportDt, "", GetSortOrder(salesDayMonthReport), DataViewRowState.CurrentRows );
            this._salesDayMonthReportView = new DataView(this._salesDayMonthReportDt, GetRowFilter(salesDayMonthReport), GetSortOrder(salesDayMonthReport), DataViewRowState.CurrentRows);
            // 2008.12.11 30413 犬飼 日計無し印刷のフィルターを追加 <<<<<<END
        }
		#endregion

        // ADD 2009/05/20 ------>>>
        #region 売上目標取得
        /// <summary>
        /// 売上目標取得処理
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="sectionCd"></param>
        /// <param name="dr"></param>
        private void GetSalesTarget(SalesDayMonthReport extraInfo, string sectionCd, ref DataRow dr)
        {
            // 1拠点につき1件取得すれば良いので、処理済拠点は処理なし
            if (this._salesTargetFinSecList.Contains(sectionCd))
            {
                return;
            }

            if (this._salesTargetAcs == null)
            {
                this._salesTargetAcs = new SalesTargetAcs();
            }

            if (this._dateGetAcs == null)
            {
                this._dateGetAcs = DateGetAcs.GetInstance();

                this._yearMonthList = new List<DateTime>();
                this._startMonthDateList = new List<DateTime>();
                this._endMonthDateList = new List<DateTime>();

                DateTime yearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                Int32 year;
                this._dateGetAcs.GetYearMonth(extraInfo.SalesDateSt, out yearMonth, out year, out startMonthDate, out endMonthDate);

                this._yearMonthList.Add(yearMonth);
                this._startMonthDateList.Add(startMonthDate);
                this._endMonthDateList.Add(endMonthDate);
            }

            List<EmpSalesTarget> empSalesTargetList;
            SearchEmpSalesTargetPara searchEmpSalesTargetPara = new SearchEmpSalesTargetPara();

            // 企業コード
            searchEmpSalesTargetPara.EnterpriseCode = extraInfo.EnterpriseCode;
            // 拠点コード
            searchEmpSalesTargetPara.SelectSectCd = new string[1];
            searchEmpSalesTargetPara.SelectSectCd[0] = sectionCd.Trim();
            // 目標設定区分
            searchEmpSalesTargetPara.TargetSetCd = 10;
            // 目標対比区分
            searchEmpSalesTargetPara.TargetContrastCd = 10;

            // 適用開始日(開始)
            searchEmpSalesTargetPara.StartApplyStaDate = this._startMonthDateList[0];
            // 適用終了日(終了)
            searchEmpSalesTargetPara.EndApplyEndDate = this._endMonthDateList[0];

            // 売上目標検索
            int status = this._salesTargetAcs.Search(out empSalesTargetList, searchEmpSalesTargetPara, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && empSalesTargetList.Count != 0)
            {
                Int64 sectionTargetMoney = 0;
                Int64 sectionTargetProfit = 0;
                
                int yearMonth = (this._yearMonthList[0].Year * 100 + this._yearMonthList[0].Month);
                
                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    if (Convert.ToInt32(empSalesTarget.TargetDivideCode) == yearMonth)
                    {
                        // 拠点目標に追加
                        sectionTargetMoney = empSalesTarget.SalesTargetMoney;
                        sectionTargetProfit = empSalesTarget.SalesTargetProfit;
                        break;
                    }
                }

                dr[DCTOK02014EA.CT_SectionTargetMoney] = sectionTargetMoney;
                dr[DCTOK02014EA.CT_SectionTargetProfit] = sectionTargetProfit;
            }
            else
            {
                dr[DCTOK02014EA.CT_SectionTargetMoney] = 0;
                dr[DCTOK02014EA.CT_SectionTargetProfit] = 0;
            }

            // 処理済み拠点を保存
            this._salesTargetFinSecList.Add(sectionCd);
        }
        #endregion
        // ADD 2009/05/20 ------<<<

        #region ◎ フィルター作成
        /// <summary>
        /// フィルター作成
        /// </summary>
        /// <returns>フィルター文字列</returns>
        private string GetRowFilter(SalesDayMonthReport salesDayMonthReport)
        {
            string filter = "";

            // 日計無し印刷
            if (salesDayMonthReport.DaySumPrtDiv != 0)
            {
                // -- 2009/08/11 -------------------------------------->>>
                // 明細がない場合も計の表示を行うため、フィルターをフォームで行うように修正
                //// 日計の伝票枚数がゼロ以上
                //filter = String.Format("{0} > 0", DCTOK02014EA.ct_Col_TermSalesSlipCount);
                // -- 2009/08/11 --------------------------------------<<<
            }

            return filter;
        }
        #endregion

        #region ◎ ソート順作成
        /// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( SalesDayMonthReport salesDayMonthReport )
		{
			StringBuilder strSortOrder = new StringBuilder();

#if False
			//集計方法が営業所毎で集計単位が0:拠点別の場合
			if ((salesDayMonthReport.TtlType == 1) || (salesDayMonthReport.TotalType == 0))
			{
				strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
			}

			//0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
			switch (salesDayMonthReport.TotalType)
			{
				//0:拠点別
				case 0:
					break;
				//1:部署別
				case 1:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SubSectionCode));
					break;
				//2:課別
				case 2:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SubSectionCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_MinSectionCode));
					break;
				//3:地区別
				case 3:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SalesAreaCode));
					break;
				//4:業種別
				case 4:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_BusinessTypeCode));
					break;
				//5:担当者別
				case 5:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SalesEmployeeCd));
					break;
				//6:受注者別
				case 6:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_FrontEmployeeNm));
					break;
				//7:発行者別
				case 7:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SalesInputCode));
					break;
				//8:得意先別
				case 8:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_CustomerCode));
					break;
				//9:地区別得意先別
				case 9:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SalesAreaCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_CustomerCode));
					break;
				//10:業種別得意先別意
				case 10:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_BusinessTypeCode));
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_CustomerCode));
					break;
				// 11:担当者別得意先別
				case 11:
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SalesEmployeeCd));
					strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_CustomerCode));
					break;
			}
#endif
            /*
            // 2008.12.02 30413 犬飼 ソート順を追加 >>>>>>START
            // 集計単位別
            switch (salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    {
                        if (salesDayMonthReport.OutType == 0)
                        {
                            // 出力順が「得意先」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_CustomerCode));
                        }
                        else if (salesDayMonthReport.OutType == 1)
                        {
                            // 出力順が「拠点」
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SectionCode));
                        }
                        else if (salesDayMonthReport.OutType == 2)
                        {
                            // 出力順が「得意先－拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_CustomerCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SectionCode));
                        }
                        else
                        {
                            // 出力順が「管理拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_CustomerCode));
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    {
                        if (salesDayMonthReport.OutType == 0)
                        {
                            // 出力順が「XXX」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_Code));
                        }
                        else if (salesDayMonthReport.OutType == 1)
                        {
                            // 出力順が「得意先」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_Code));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_CustomerCode));
                        }
                        else if (salesDayMonthReport.OutType == 2)
                        {
                            // 出力順が「XXX－拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_Code));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SectionCode));
                        }
                        else
                        {
                            // 出力順が「管理拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_Code));
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    {
                        if (salesDayMonthReport.OutType == 0)
                        {
                            // 出力順が「XXX」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_Code));
                            break;
                        }
                        else if (salesDayMonthReport.OutType == 1)
                        {
                            // 出力順が「得意先」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_Code));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_CustomerCode));
                        }
                        else if (salesDayMonthReport.OutType == 2)
                        {
                            // 出力順が「XXX－拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_Code));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SectionCode));
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:              // 販売区分
                    {
                        strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SectionCode));
                        strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_Code));
                        break;
                    }
            }
            // 2008.12.02 30413 犬飼 ソート順を追加 <<<<<<END
            */
            // ---ADD 2009/02/06 不具合対応[10783] -------------------------------------------------------------------->>>>>
            //※表示が0埋めの文字列なので、ソートも文字列ソートにする必要がある
            switch (salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    {
                        if (salesDayMonthReport.OutType == 0)
                        {
                            // 出力順が「得意先」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCustomerCode));
                        }
                        else if (salesDayMonthReport.OutType == 1)
                        {
                            // 出力順が「拠点」
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortSectionCode));
                        }
                        else if (salesDayMonthReport.OutType == 2)
                        {
                            // 出力順が「得意先－拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortCustomerCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortSectionCode));
                        }
                        else
                        {
                            // 出力順が「管理拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCustomerCode));
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    {
                        if (salesDayMonthReport.OutType == 0)
                        {
                            // 出力順が「XXX」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCode));
                        }
                        else if (salesDayMonthReport.OutType == 1)
                        {
                            // 出力順が「得意先」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCustomerCode));
                        }
                        else if (salesDayMonthReport.OutType == 2)
                        {
                            // 出力順が「XXX－拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortSectionCode));
                        }
                        else
                        {
                            // 出力順が「管理拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCode));
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    {
                        if (salesDayMonthReport.OutType == 0)
                        {
                            // 出力順が「XXX」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCode));
                            break;
                        }
                        else if (salesDayMonthReport.OutType == 1)
                        {
                            // 出力順が「得意先」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCustomerCode));
                        }
                        else if (salesDayMonthReport.OutType == 2)
                        {
                            // 出力順が「XXX－拠点」
                            strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortCode));
                            strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortSectionCode));
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:              // 販売区分
                    {
                        strSortOrder.Append(string.Format("{0},", DCTOK02014EA.ct_Col_SortSectionCode));
                        strSortOrder.Append(string.Format("{0}", DCTOK02014EA.ct_Col_SortCode));
                        break;
                    }
            }
            // ---ADD 2009/02/06 不具合対応[10783] --------------------------------------------------------------------<<<<<

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

	}
}
