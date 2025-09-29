//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入日報月報アクセス
// プログラム概要   : 仕入日報月報で使用するデータを取得する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 立花 裕輔
// 作 成 日  2007/09/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/08/08  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号  11209       作成担当 : 上野 俊治
// 修 正 日  2009/02/10  修正内容 : 障害対応11209(返品、値引項目が帳票上プラスになるよう正負を反転)
//----------------------------------------------------------------------------//
// 管理番号  12834       作成担当 : 工藤 恵優
// 修 正 日  2009/04/07  修正内容 : 障害対応12834(集計対象を拠点→仕入計上拠点へ修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄偉兵
// 修 正 日  2009/09/08  修正内容 : PM.NS-2-B・ＰＭ．ＮＳ保守依頼①
//                                          過去分表示対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 許培珠
// 修 正 日  2012/04/05  修正内容 : redmine#29143 5/24配信分 仕入先コードにてソートされていない件
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
    /// 仕入日報月報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 仕入日報月報で使用するデータを取得する。</br>
    /// <br>Programmer	: 96186 立花 裕輔</br>
    /// <br>Date		: 2007.09.03</br>
    /// <br>UpdateNote  : 2008/08/08 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br>    
    /// <br>UpdateNote  : 2009/02/10 30452 上野 俊治</br>
    /// <br>        	 ・障害対応11209(返品、値引項目が帳票上プラスになるよう正負を反転)</br>
    /// <br>UpdateNote  : 2009/04/07 30434 工藤 恵優</br>
    /// <br>        	 ・障害対応12834(集計対象を拠点→仕入計上拠点へ修正)</br>
    /// <br>Update Note  : 2009/09/08 黄偉兵</br>
    /// <br>               PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>                         過去分表示対応</br>
    /// </remarks>
	public class StockMoveAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 仕入日報月報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入日報月報アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public StockMoveAcs()
		{
			this._iStockDayMonthReportDB = (IStockDayMonthReportDB)MediationStockDayMonthReportDB.GetStockConfDB();
		}

		/// <summary>
		/// 仕入日報月報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入日報月報アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		static StockMoveAcs()
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
		IStockDayMonthReportDB _iStockDayMonthReportDB;

		private DataTable _stockDayMonthReportDt;			// 印刷DataTable
		private DataView _stockDayMonthReportView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockMoveDataView
		{
			get{ return this._stockDayMonthReportView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// 入金データ取得
		/// </summary>
		/// <param name="stockDayMonthReport">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する入金データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public int SearchStockMoveMain( StockDayMonthReport stockDayMonthReport, out string errMsg )
		{
			return this.SearchStockDayMonthReportProc( stockDayMonthReport, out errMsg );
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
		/// <param name="stockDayMonthReport"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する仕入データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private int SearchStockDayMonthReportProc( StockDayMonthReport stockDayMonthReport, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCKOU02105EA.CreateDataTable(ref this._stockDayMonthReportDt);
				
				// 抽出条件展開  --------------------------------------------------------------
				StockDayMonthReportWork stockDayMonthReportWork = new StockDayMonthReportWork();
				status = this.DevStockDayMonthReport(stockDayMonthReport, out stockDayMonthReportWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                //StockDayMonthReportDataWork aaa = new StockDayMonthReportDataWork();
				object stockDayMonthReportDataWork;

				status = _iStockDayMonthReportDB.Search(out stockDayMonthReportDataWork, stockDayMonthReportWork);

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( stockDayMonthReport, (ArrayList)stockDayMonthReportDataWork );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "仕入データの取得に失敗しました。";
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
		/// <param name="stockDayMonthReport">UI抽出条件クラス</param>
		/// <param name="stockMoveListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
		private int DevStockDayMonthReport ( StockDayMonthReport stockDayMonthReport, out StockDayMonthReportWork stockDayMonthReportWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockDayMonthReportWork = new StockDayMonthReportWork();
			try
			{
                // 企業コード
				stockDayMonthReportWork.EnterpriseCode = stockDayMonthReport.EnterpriseCode;

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //stockDayMonthReportWork.IsSelectAllSection = stockDayMonthReport.IsSelectAllSection;
                //stockDayMonthReportWork.IsOutputAllSecRec = stockDayMonthReport.IsOutputAllSecRec;
                //stockDayMonthReportWork.SectionCode = stockDayMonthReport.SectionCode;
                //stockDayMonthReportWork.CustomerCodeSt = stockDayMonthReport.CustomerCodeSt;
                //stockDayMonthReportWork.CustomerCodeEd = stockDayMonthReport.CustomerCodeEd;
                //stockDayMonthReportWork.StockAgentCodeSt = stockDayMonthReport.StockAgentCodeSt;
                //stockDayMonthReportWork.StockAgentCodeEd = stockDayMonthReport.StockAgentCodeEd;
                //stockDayMonthReportWork.StockDateSt = stockDayMonthReport.StockDateSt;
                //stockDayMonthReportWork.StockDateEd = stockDayMonthReport.StockDateEd;
                //stockDayMonthReportWork.PrintType = stockDayMonthReport.PrintType;
                //stockDayMonthReportWork.TotalDay = stockDayMonthReport.TotalDay;
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                // 拠点コード
                stockDayMonthReportWork.DepositStockSecCodeList = stockDayMonthReport.SectionCode;
                // 仕入先コード（開始）
                stockDayMonthReportWork.SupplierCdSt = stockDayMonthReport.SupplierCodeSt;
                // 仕入先コード（終了）
                stockDayMonthReportWork.SupplierCdEd = stockDayMonthReport.SupplierCodeEd;
                // 開始仕入日（日計）
                stockDayMonthReportWork.DayStockDateSt = stockDayMonthReport.DayStockDateSt;
                // 終了仕入日（日計）
                stockDayMonthReportWork.DayStockDateEd = stockDayMonthReport.DayStockDateEd;
                // 開始仕入日（累計）
                stockDayMonthReportWork.MonthStockDateSt = stockDayMonthReport.MonthStockDateSt;
                // 終了仕入日（累計）
                stockDayMonthReportWork.MonthStockDateEd = stockDayMonthReport.MonthStockDateEd;
                // --- ADD 2008/08/08 --------------------------------<<<<< 
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
		/// <param name="stockDayMonthReport">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
		/// </remarks>
		private void DevStockMoveData ( StockDayMonthReport stockDayMonthReport, ArrayList list )
		{
			DataRow dr=null;
            int supplierCd = -1;  // 仕入先コード

            // ADD 2009/01/14 不具合対応[9686] ---------->>>>>
            string previousKey = string.Empty;
            IDictionary<string, DataRow> dataRowMap = new Dictionary<string, DataRow>();
            // ADD 2009/01/14 不具合対応[9686] ----------<<<<<

			foreach ( StockDayMonthReportDataWork stockDayMonthReportDataWork in list )
			{
                // ADD 2009/01/14 不具合対応[9686] ---------->>>>>
                // TODO:StockDayMonthReportDataWork.SectionCodeは使用しないのが望ましいが、影響範囲が広いので、.StockAddUpSectionCdの値を再設定する処理としておく
                stockDayMonthReportDataWork.SectionCode = stockDayMonthReportDataWork.StockAddUpSectionCd;  // ADD 2009/04/07 不具合対応[12834]：集計対象を拠点→仕入計上拠点へ修正
                string currentKey = stockDayMonthReportDataWork.SupplierCd.ToString("000000") + stockDayMonthReportDataWork.SectionCode.Trim();
                if (!currentKey.Equals(previousKey))
                // ADD 2009/01/14 不具合対応[9686] ----------<<<<<

                // --- ADD 2008/08/08 -------------------------------->>>>>
                // DEL 2009/01/14 不具合対応[9686]↓
                // 仕入先コードが変わったら行追加
                //if (stockDayMonthReportDataWork.SupplierCd != supplierCd)
                {
                    // DEL 2009/01/14 不具合対応[9686] ---------->>>>>
                    //if (supplierCd != -1)   // 初回はスキップ
                    //{
                    //    // 合計計算
                    //    CalculationTotal(ref dr);

                    //    // TableにAdd
                    //    this._stockDayMonthReportDt.Rows.Add(dr);
                    //}
                    // DEL 2009/01/14 不具合対応[9686] ----------<<<<<

                    // --- ADD 2008/08/08 -------------------------------->>>>>
                    if (dataRowMap.ContainsKey(currentKey))
                    {
                        dr = dataRowMap[currentKey];
                    }
                    else
                    {
                        dr = this._stockDayMonthReportDt.NewRow();
                        {
                            dr[DCKOU02105EA.ct_Col_StckPriceDayTotalZai] = 0;     // 仕入金額日計(在庫)
                            dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalZai] = 0;   // 仕入金額月計(在庫)
                            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] = 0;        // 返品金額日計(在庫)
                            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] = 0;      // 返品金額月計(在庫)
                            dr[DCKOU02105EA.ct_Col_DisDayTotalZai] = 0;           // 値引金額日計(在庫)
                            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai] = 0;      // 値引金額月計(在庫)
                            dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalZai] = 0;     // 純仕入額日計(在庫)
                            dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalZai] = 0;   // 純仕入額月計(在庫)

                            dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] = 0;    // 仕入金額日計(取寄)
                            dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] = 0;  // 仕入金額月計(取寄)
                            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori] = 0;       // 返品金額日計(取寄)
                            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori] = 0;     // 返品金額月計(取寄)
                            dr[DCKOU02105EA.ct_Col_DisDayTotalTori] = 0;          // 値引金額日計(取寄)
                            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori] = 0;     // 値引金額月計(取寄)
                            dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalTori] = 0;    // 純仕入額日計(取寄)
                            dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalTori] = 0;  // 純仕入額月計(取寄)

                            dr[DCKOU02105EA.ct_Col_StckPriceDayTotalGou] = 0;     // 仕入金額日計(合計)
                            dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalGou] = 0;   // 仕入金額月計(合計)
                            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalGou] = 0;        // 返品金額日計(合計)
                            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalGou] = 0;      // 返品金額月計(合計)
                            dr[DCKOU02105EA.ct_Col_DisDayTotalGou] = 0;           // 値引金額日計(合計)
                            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalGou] = 0;      // 値引金額月計(合計)
                            dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou] = 0;     // 純仕入額日計(合計)
                            dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou] = 0;   // 純仕入額月計(合計)
                        }
                        dataRowMap.Add(currentKey, dr);
                    }
                    // ADD 2009/01/14 不具合対応[9686] ----------<<<<<

                    // 仕入先コード保持
                    supplierCd = stockDayMonthReportDataWork.SupplierCd;

                    previousKey = currentKey;   // ADD 2009/01/14 不具合対応[9686]

                    // DEL 2009/01/14 不具合対応[9686] ---------->>>>>
                    #region 削除コード
                    //dr[DCKOU02105EA.ct_Col_StckPriceDayTotalZai] = 0;     // 仕入金額日計(在庫)
                    //dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalZai] = 0;   // 仕入金額月計(在庫)
                    //dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] = 0;        // 返品金額日計(在庫)
                    //dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] = 0;      // 返品金額月計(在庫)
                    //dr[DCKOU02105EA.ct_Col_DisDayTotalZai] = 0;           // 値引金額日計(在庫)
                    //dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai] = 0;      // 値引金額月計(在庫)
                    //dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalZai] = 0;     // 純仕入額日計(在庫)
                    //dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalZai] = 0;   // 純仕入額月計(在庫)

                    //dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] = 0;    // 仕入金額日計(取寄)
                    //dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] = 0;  // 仕入金額月計(取寄)
                    //dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori] = 0;       // 返品金額日計(取寄)
                    //dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori] = 0;     // 返品金額月計(取寄)
                    //dr[DCKOU02105EA.ct_Col_DisDayTotalTori] = 0;          // 値引金額日計(取寄)
                    //dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori] = 0;     // 値引金額月計(取寄)
                    //dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalTori] = 0;    // 純仕入額日計(取寄)
                    //dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalTori] = 0;  // 純仕入額月計(取寄)

                    //dr[DCKOU02105EA.ct_Col_StckPriceDayTotalGou] = 0;     // 仕入金額日計(合計)
                    //dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalGou] = 0;   // 仕入金額月計(合計)
                    //dr[DCKOU02105EA.ct_Col_RetGdsDayTotalGou] = 0;        // 返品金額日計(合計)
                    //dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalGou] = 0;      // 返品金額月計(合計)
                    //dr[DCKOU02105EA.ct_Col_DisDayTotalGou] = 0;           // 値引金額日計(合計)
                    //dr[DCKOU02105EA.ct_Col_DisDayMonthTotalGou] = 0;      // 値引金額月計(合計)
                    //dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou] = 0;     // 純仕入額日計(合計)
                    //dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou] = 0;   // 純仕入額月計(合計)
                    #endregion  // 削除コード
                    // DEL 2009/01/14 不具合対応[9686] ----------<<<<<
                }
                // --- ADD 2008/08/08 --------------------------------<<<<< 

				// 取得データ展開
				#region 取得データ展開
				dr[DCKOU02105EA.ct_Col_SectionCode			] = stockDayMonthReportDataWork.SectionCode;     // UNDONE:拠点コード
				dr[DCKOU02105EA.ct_Col_SectionGuideNm		] = stockDayMonthReportDataWork.SectionGuideNm;  // 拠点ガイド名称

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //dr[DCKOU02105EA.ct_Col_CustomerCode			] = stockDayMonthReportDataWork.CustomerCode;  // 得意先コード
                //dr[DCKOU02105EA.ct_Col_CustomerName			] = stockDayMonthReportDataWork.CustomerName;  // 得意先名称
                //dr[DCKOU02105EA.ct_Col_CustomerName2		] = stockDayMonthReportDataWork.CustomerName2;     // 得意先名称2
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                dr[DCKOU02105EA.ct_Col_SupplierCode] = stockDayMonthReportDataWork.SupplierCd;  // 仕入先コード
                dr[DCKOU02105EA.ct_Col_SupplierSnm] = stockDayMonthReportDataWork.SupplierSnm;  // 仕入先名称
                // --- ADD 2008/08/08 --------------------------------<<<<< 

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //dr[DCKOU02105EA.ct_Col_StockAgentCode		] = stockDayMonthReportDataWork.StockAgentCode;  // 仕入担当者コード
                //dr[DCKOU02105EA.ct_Col_StockAgentName		] = stockDayMonthReportDataWork.StockAgentName;  // 仕入担当者名称
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                if (stockDayMonthReportDataWork.StockOrderDivCd == 1)  // 仕入在庫取寄せ区分＝「1:在庫」
                {
                    switch (stockDayMonthReportDataWork.StockSlipCdDtl)  // 仕入伝票区分
                    {
                        case 0:  // 仕入金額

                            // 仕入金額日計
                            dr[DCKOU02105EA.ct_Col_StckPriceDayTotalZai] =
                                (long)dr[DCKOU02105EA.ct_Col_StckPriceDayTotalZai] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;        

                            // 仕入金額月計
                            dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalZai] =
                                (long)dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalZai] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;  

                            break;
                        case 1:  // 返品金額

                            // 返品金額日計
                            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] =
                                (long)dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;        
                            
                            // 返品金額月計
                            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] =
                                (long)dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;  

                            break;
                        case 2:  // 値引金額

                            // 値引金額日計
                            dr[DCKOU02105EA.ct_Col_DisDayTotalZai] =
                                (long)dr[DCKOU02105EA.ct_Col_DisDayTotalZai] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;           
                            
                            // 値引金額月計
                            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai] =
                                (long)dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;  

                            break;
                        default:
                            break;
                    }
                }
                else if (stockDayMonthReportDataWork.StockOrderDivCd == 0)   // 仕入在庫取寄せ区分＝「0:取寄せ」
                {
                    switch (stockDayMonthReportDataWork.StockSlipCdDtl)  // 仕入伝票区分
                    {
                        case 0:  // 仕入金額

                            // 仕入金額日計
                            dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] =
                                (long)dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;

                            // 仕入金額月計
                            dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] =
                                (long)dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;

                            break;
                        case 1:  // 返品金額

                            // 返品金額日計
                            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori] =
                                (long)dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;
                            
                            // 返品金額月計
                            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori] =
                                (long)dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;

                            break;
                        case 2:  // 値引金額

                            // --- ADD 2009/09/08 ---------->>>>>
                            // 行値引金額
                            if (stockDayMonthReportDataWork.StockCount == 0)
                            {
                                // 仕入金額日計
                                dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] =
                                    (long)dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;

                                // 仕入金額月計
                                dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] =
                                    (long)dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;

                                break;
                            }
                            // 商品値引金額
                            // --- ADD 2009/09/08 ----------<<<<<

                            // 値引金額日計
                            dr[DCKOU02105EA.ct_Col_DisDayTotalTori] =
                                (long)dr[DCKOU02105EA.ct_Col_DisDayTotalTori] + (long)stockDayMonthReportDataWork.DayStockPriceTaxExc;

                            // 値引金額月計
                            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori] =
                                (long)dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori] + (long)stockDayMonthReportDataWork.MonthStockPriceTaxExc;

                            break;
                        default:
                            break;
                    }
                }
                // --- ADD 2008/08/08 --------------------------------<<<<< 

                // --- DEL 2008/08/08 -------------------------------->>>>>
                #region 削除コード
                //dr[DCKOU02105EA.ct_Col_StckPriceDayTotal	] = stockDayMonthReportDataWork.StckPriceDayTotal;  // 仕入金額日計
                //dr[DCKOU02105EA.ct_Col_RetGdsDayTotal		] = stockDayMonthReportDataWork.RetGdsDayTotal;     // 返品金額日計
                //dr[DCKOU02105EA.ct_Col_DisDayTotal			] = stockDayMonthReportDataWork.DisDayTotal;        // 値引金額日計

                //if (stockDayMonthReportDataWork.StckPriceDayTotal == 0)
                //{
                //    dr[DCKOU02105EA.ct_Col_RetGdsDayRate] = 0;
                //}
                //else
                //{
                //    dr[DCKOU02105EA.ct_Col_RetGdsDayRate] = Math.Abs((double)stockDayMonthReportDataWork.RetGdsDayTotal * 100 / (double)stockDayMonthReportDataWork.StckPriceDayTotal); // 返品率日計
                //}

                //if (stockDayMonthReportDataWork.StckPriceDayTotal == 0)
                //{
                //    dr[DCKOU02105EA.ct_Col_DisDayRate] = 0;
                //}
                //else
                //{
                //    dr[DCKOU02105EA.ct_Col_DisDayRate] = Math.Abs((double)stockDayMonthReportDataWork.DisDayTotal * 100 / (double)stockDayMonthReportDataWork.StckPriceDayTotal); // 値引率日計
                //}

                //dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotal	] = stockDayMonthReportDataWork.NetStcPrcDayTotal;  // 純仕入額日計

                //dr[DCKOU02105EA.ct_Col_StckPriceMonthTotal] = stockDayMonthReportDataWork.StckPriceMonthTotal;  // 仕入金額月計
                //dr[DCKOU02105EA.ct_Col_RetGdsMonthTotal] = stockDayMonthReportDataWork.RetGdsMonthTotal;        // 返品金額月計
                //dr[DCKOU02105EA.ct_Col_DisDayMonthTotal] = stockDayMonthReportDataWork.DisDayMonthTotal;        // 値引金額月計
                //dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotal] = stockDayMonthReportDataWork.NetStcPrcMonthTotal;  // 純仕入額月計

                //if (stockDayMonthReportDataWork.StckPriceMonthTotal == 0)
                //{
                //    dr[DCKOU02105EA.ct_Col_RetGdsMonthRate] = 0;
                //}
                //else
                //{
                //    dr[DCKOU02105EA.ct_Col_RetGdsMonthRate] = Math.Abs((double)stockDayMonthReportDataWork.RetGdsMonthTotal * 100 / (double)stockDayMonthReportDataWork.StckPriceMonthTotal); // 返品率月計
                //}
                //if(stockDayMonthReportDataWork.StckPriceMonthTotal == 0)
                //{
                //    dr[DCKOU02105EA.ct_Col_DisDayMonthRate] = 0;
                //}
                //else
                //{
                //    dr[DCKOU02105EA.ct_Col_DisDayMonthRate] = Math.Abs((double)stockDayMonthReportDataWork.DisDayMonthTotal * 100 / (double)stockDayMonthReportDataWork.StckPriceMonthTotal); // 値引率月計
                //}

                //// 帳票種別(0:営業所別 1:担当者別 2:仕入先別 3:担当別仕入先別)
                //switch (stockDayMonthReport.PrintType)
                //{
                //    case 0:
                //        dr[DCKOU02105EA.ct_Col_DetailLine] = stockDayMonthReportDataWork.SectionCode;
                //        dr[DCKOU02105EA.ct_Col_DetailLineName] = stockDayMonthReportDataWork.SectionGuideNm;
                //        break;
                //    case 1:
                //        dr[DCKOU02105EA.ct_Col_DetailLine] = stockDayMonthReportDataWork.StockAgentCode;
                //        dr[DCKOU02105EA.ct_Col_DetailLineName] = stockDayMonthReportDataWork.StockAgentName;
                //        break;
                //    case 2:
                //        dr[DCKOU02105EA.ct_Col_DetailLine] = stockDayMonthReportDataWork.CustomerCode.ToString("d9");
                //        dr[DCKOU02105EA.ct_Col_DetailLineName] = stockDayMonthReportDataWork.CustomerName;
                //        break;
                //    case 3:
                //        dr[DCKOU02105EA.ct_Col_DetailLine] = stockDayMonthReportDataWork.CustomerCode.ToString("d9");
                //        dr[DCKOU02105EA.ct_Col_DetailLineName] = stockDayMonthReportDataWork.CustomerName;
                //        break;
                //}
                #endregion  // 削除コード
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                // 帳票種別(1:拠点別 2:仕入先別)
                switch (stockDayMonthReport.PrintType)
                {
                    case 1:
                        dr[DCKOU02105EA.ct_Col_DetailLine] = stockDayMonthReportDataWork.SupplierCd.ToString("d9");
                        dr[DCKOU02105EA.ct_Col_DetailLineName] = stockDayMonthReportDataWork.SupplierSnm;
                        break;
                    case 2:
                        dr[DCKOU02105EA.ct_Col_DetailLine] = stockDayMonthReportDataWork.SectionCode;
                        dr[DCKOU02105EA.ct_Col_DetailLineName] = stockDayMonthReportDataWork.SectionGuideNm;
                        break;
                }
                // --- ADD 2008/08/08 --------------------------------<<<<< 

				#endregion
            }   // foreach ( StockDayMonthReportDataWork stockDayMonthReportDataWork in list )

            // DEL 2009/01/14 不具合対応[9686] ---------->>>>>
            // 合計計算
            //CalculationTotal(ref dr);

            // TableにAdd
            //this._stockDayMonthReportDt.Rows.Add(dr);
            // DEL 2009/01/14 不具合対応[9686] ----------<<<<<
            // ADD 2009/01/14 不具合対応[9686] ---------->>>>>
            foreach (DataRow dataRow in dataRowMap.Values)
            {
                // 合計計算
                CalculationTotal(dataRow);

                // --- ADD 2009/02/10 -------------------------------->>>>>
                // 値引、返品項目の正負補正
                ReviseMinusItems(dataRow);
                // --- ADD 2009/02/10 --------------------------------<<<<<

                // TableにAdd
                this._stockDayMonthReportDt.Rows.Add(dataRow);
            }
            // ADD 2009/01/14 不具合対応[9686] ----------<<<<<

			// DataView作成
			this._stockDayMonthReportView = new DataView( this._stockDayMonthReportDt, "", GetSortOrder(stockDayMonthReport), DataViewRowState.CurrentRows );

            // ADD 2009/01/14 不具合対応[9686] ---------->>>>>
            // 帳票種別(1:拠点別 2:仕入先別)
            switch (stockDayMonthReport.PrintType)
            {
                case 1:
                    //this._stockDayMonthReportView.Sort = DCKOU02105EA.ct_Col_SectionCode;// DEL 2012/04/05 xupz for redmine#29143
                    this._stockDayMonthReportView.Sort = DCKOU02105EA.ct_Col_SectionCode + "," + DCKOU02105EA.ct_Col_SupplierCode;// ADD 2012/04/05 xupz for redmine#29143
                    break;
                case 2:
                    //this._stockDayMonthReportView.Sort = DCKOU02105EA.ct_Col_SupplierCode;// DEL 2012/04/05 xupz for redmine#29143
                    this._stockDayMonthReportView.Sort = DCKOU02105EA.ct_Col_SupplierCode + "," + DCKOU02105EA.ct_Col_SectionCode;// ADD 2012/04/05 xupz for redmine#29143
                    break;
            }
            // ADD 2009/01/14 不具合対応[9686] ----------<<<<<
		}

        /// <summary>
        /// 合計計算処理
        /// </summary>
        /// <param name="Dr">DataRow</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 合計を計算する。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void CalculationTotal(DataRow Dr)   // MOD 2009/01/14 不具合対応[9686] (ref DataRow Dr)→(DataRow Dr)
        {
           // 純仕入額日計
            Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalZai] =
                (long)Dr[DCKOU02105EA.ct_Col_StckPriceDayTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_DisDayTotalZai];        
            // 純仕入額月計
            Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalZai] =
                (long)Dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai];  
            // 純仕入額日計
            Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalTori] =
                (long)Dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori] + (long)Dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori] + (long)Dr[DCKOU02105EA.ct_Col_DisDayTotalTori];
            // 純仕入額月計
            Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalTori] =
                (long)Dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori] + (long)Dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori] + (long)Dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori];

            // 仕入金額日計(合計)
            Dr[DCKOU02105EA.ct_Col_StckPriceDayTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_StckPriceDayTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_StckPriceDayTotalTori];
            // 仕入金額月計(合計)
            Dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_StckPriceMonthTotalTori];
            // 返品金額日計(合計)
            Dr[DCKOU02105EA.ct_Col_RetGdsDayTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori];
            // 返品金額月計(合計)
            Dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori];
            // 値引金額日計(合計)
            Dr[DCKOU02105EA.ct_Col_DisDayTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_DisDayTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_DisDayTotalTori];
            // 値引金額月計(合計)
            Dr[DCKOU02105EA.ct_Col_DisDayMonthTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori];
            // 純仕入額日計(合計)
            Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalTori];
            // 純仕入額月計(合計)
            Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou] =
                (long)Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalZai] + (long)Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalTori];

            double dblWork;

            if ((long)Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou] != 0)
            {
                // 在庫比率日計(合計)
                dblWork = double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalZai].ToString()) / double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou].ToString()) * 100;
                // 四捨五入(少数３桁目を四捨五入)
                dblWork = Math.Round(dblWork, 2, MidpointRounding.AwayFromZero);

                Dr[DCKOU02105EA.ct_Col_StckZaiRatioDayTotalGou] = dblWork;
            }
            else
            {
                Dr[DCKOU02105EA.ct_Col_StckZaiRatioDayTotalGou] = 0;
            }

            if ((long)Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou] != 0)
            {
                // 在庫比率月計(合計)
                dblWork = double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalZai].ToString()) / double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou].ToString()) * 100;
                // 四捨五入(少数３桁目を四捨五入)
                dblWork = Math.Round(dblWork, 2, MidpointRounding.AwayFromZero);

                Dr[DCKOU02105EA.ct_Col_StckZaiRatioMonthTotalGou] = dblWork;
            }
            else
            {
                Dr[DCKOU02105EA.ct_Col_StckZaiRatioMonthTotalGou] = 0;
            }

            if ((long)Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou] != 0)
            {
                // 取寄比率日計(合計)
                dblWork = double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalTori].ToString()) / double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcDayTotalGou].ToString()) * 100;
                // 四捨五入(少数３桁目を四捨五入)
                dblWork = Math.Round(dblWork, 2, MidpointRounding.AwayFromZero);
                
                Dr[DCKOU02105EA.ct_Col_StckToriRatioDayTotalGou] = dblWork;
            }
            else
            {
                Dr[DCKOU02105EA.ct_Col_StckToriRatioDayTotalGou] = 0;
            }

            if ((long)Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou] != 0)
            {
                // 取寄比率月計(合計) 
                dblWork = double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalTori].ToString()) / double.Parse(Dr[DCKOU02105EA.ct_Col_NetStcPrcMonthTotalGou].ToString()) * 100;
                // 四捨五入(少数３桁目を四捨五入)
                dblWork = Math.Round(dblWork, 2, MidpointRounding.AwayFromZero);

                Dr[DCKOU02105EA.ct_Col_StckToriRatioMonthTotalGou] = dblWork;
            }
            else
            {
                Dr[DCKOU02105EA.ct_Col_StckToriRatioMonthTotalGou] = 0;
            }
        }

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// <summary>
        /// マイナス項目正負補正
        /// </summary>
        /// <param name="dr"></param>
        /// <remarks>
        /// <br>Note       : 返品、値引項目の正負を反転する。</br>
        /// </remarks>
        private void ReviseMinusItems(DataRow dr)
        {
            // 返品金額日計(在庫)
            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_RetGdsDayTotalZai]);
            // 値引金額日計(在庫)
            dr[DCKOU02105EA.ct_Col_DisDayTotalZai] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_DisDayTotalZai]);
            // 返品金額月計(在庫)
            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalZai]);
            // 値引金額月計(在庫)
            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_DisDayMonthTotalZai]);
            // 返品金額日計(取寄)
            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_RetGdsDayTotalTori]);
            // 値引金額日計(取寄)
            dr[DCKOU02105EA.ct_Col_DisDayTotalTori] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_DisDayTotalTori]);
            // 返品金額月計(取寄)
            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalTori]);
            // 値引金額月計(取寄)
            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_DisDayMonthTotalTori]);
            // 返品金額日計(合計)
            dr[DCKOU02105EA.ct_Col_RetGdsDayTotalGou] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_RetGdsDayTotalGou]);
            // 値引金額日計(合計)
            dr[DCKOU02105EA.ct_Col_DisDayTotalGou] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_DisDayTotalGou]);
            // 返品金額月計(合計)
            dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalGou] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_RetGdsMonthTotalGou]);
            // 値引金額月計(合計)
            dr[DCKOU02105EA.ct_Col_DisDayMonthTotalGou] = this.RevisePlusMinus((Int64)dr[DCKOU02105EA.ct_Col_DisDayMonthTotalGou]);
        }

        /// <summary>
        /// 正負を反転する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Int64 RevisePlusMinus(Int64 value)
        {
            if (value != 0)
            {
                return value * -1;
            }
            else
            {
                return 0;
            }
        }
        // --- ADD 2009/02/10 --------------------------------<<<<<
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( StockDayMonthReport stockDayMonthReport )
		{
			StringBuilder strSortOrder = new StringBuilder();
#if False

			// 2007.06.01 kubo change ------------------------>
			if ( !stockDayMonthReport.IsSelectAllSection )
			{
				// 全社選択されてないとき
				// 主拠点
				strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_MainSectionCode ) );
			}
			// 2007.06.01 kubo change <------------------------

			// 主倉庫
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_MainWhareHouseCode ) );
			// 絞り込み日付
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_ExtractDate ) );
			// 絞り込み拠点
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_ExtractSectionCode ) );
			// 絞り込み拠点
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_ExtractWhareHouseCode ) );
			// 移動伝票番号
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_StockMoveSlipNo ) );
			#region // 2007.06.01 kubo del
			//// 移動行番号
			//strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_StockMoveRowNo ) );
			//// 移動行詳細番号
			//strSortOrder.Append( string.Format("{0}", MAZAI02034EA.ct_Col_StockMoveExpNum ) );
			#endregion
			// 仕入先コード
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_CustomerCode ) );	// 2007.06.01 kubo add
			// メーカーコード
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_MakerCode ) );
			// 商品コード
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_GoodsCode ) );
			// 製造番号
			strSortOrder.Append( string.Format("{0}", MAZAI02034EA.ct_Col_ProDuctNumber ) );
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
	}
}
