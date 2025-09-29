//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/27  修正内容 : Redmine 障害報告 #23232 の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/08/03  修正内容 : Redmine 障害報告 #23232 の対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using System.Reflection;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// キャンペーン実績表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: キャンペーン実績表で使用するデータを取得する。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2011/05/19</br>
    /// <br>Update Note : 2011/07/27 高峰</br>
    /// <br>            : Redmine 障害報告 #23232 の対応</br>
    /// <br>Update Note : 2011/08/03 yangmj</br>
    /// <br>            : Redmine 障害報告 #23232 の対応</br>
    /// </remarks>
	public class CampaignRsltListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// キャンペーン実績表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : キャンペーン実績表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 田建委</br>
	    /// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public CampaignRsltListAcs()
		{
			this._iCampaignRsltListResultDB = (ICampaignRsltListResultDB)MediationCampaignRsltListResultDB.GetCampaignRsltListResultDB();

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
		}

		/// <summary>
		/// キャンペーン実績表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : キャンペーン実績表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 田建委</br>
	    /// <br>Date       : 2011/05/19</br>
		/// </remarks>
		static CampaignRsltListAcs()
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
		ICampaignRsltListResultDB _iCampaignRsltListResultDB;

        private DataTable _campaignRsltListDt;			// 印刷DataTable
        private DataView _campaignRsltListView;	        // 印刷DataView

        private CampaignTargetValue _dictionaryCampTarget;  // DictionaryのValue用クラス
        private Dictionary<string, CampaignTargetValue> _totalDic = new Dictionary<string, CampaignTargetValue>();

        private const string ctSalesTargetMoney = "SalesTargetMoney";   // 売上目標金額
        private const string ctSalesTargetProfit = "SalesTargetProfit"; // 売上目標粗利額
        private const string ctSalesTargetCount = "SalesTargetCount";   // 売上目標数量

        //日付取得部品
        private DateGetAcs _dateGet;

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
        public DataView CampaignView
		{
            get { return this._campaignRsltListView; }
		}
		#endregion ■ Public Property

		#region ■ Private Method
        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        /// <remarks>
        /// <br>Note       : 率取得処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private double GetRatio(object numerator, object denominator)
        {
            double workRate;
            double numeratorD = Convert.ToDouble(numerator);
            double denominatorD = Convert.ToDouble(denominator);

            if (denominatorD == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numeratorD / denominatorD) * 100;
            }

            return workRate;
        }

        #region [ReadPrtOutSet]
        /// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
        /// <br>Note       : 帳票出力設定読込を行います。</br>
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = string.Empty;	

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
							retPrtOutSet = stc_PrtOutSet.Clone();
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

        #endregion [ReadPrtOutSet]

        #region [抽出処理] 
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="campaignRsltList">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : データ取得を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public int SeachCampaignMain(CampaignRsltList campaignRsltList, out string errMsg)
        {
            return SeachCampaignMainProc(campaignRsltList, out errMsg);
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="campaignRsltList">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : データ取得を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private int SeachCampaignMainProc(CampaignRsltList campaignRsltList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKHN02054EA.CreateDataTable(ref this._campaignRsltListDt);

                // 抽出条件展開  --------------------------------------------------------------
                CampaignstRsltListPrtWork paramWork = new CampaignstRsltListPrtWork();
                status = this.DevSalesDayMonthReport(campaignRsltList, out paramWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object campaignstSalseWork = null;
                object campaignstTargetWork = null;

                status = this._iCampaignRsltListResultDB.Search(out campaignstSalseWork, out campaignstTargetWork, paramWork);
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList resultLst = new ArrayList();
                            ArrayList salesLst = new ArrayList();
                            ArrayList campaignstSalesWorkLst = (ArrayList)campaignstSalseWork;
                            ArrayList campaignstTargetWorkLst = (ArrayList)campaignstTargetWork;
                            if (campaignstSalesWorkLst == null || campaignstTargetWorkLst == null || campaignstSalesWorkLst.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }
                            // 売上データの合計
                            SumSalesData(campaignstSalesWorkLst, campaignRsltList, ref salesLst);
                            if (salesLst.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }

                            // データ抽出処理
                            SetDataFrmTargetToSales(salesLst, campaignstTargetWorkLst, campaignRsltList, out resultLst);

                            // データ展開処理
                            DevStockMoveData(campaignRsltList, resultLst);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "売上明細データの取得に失敗しました。";
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

        #endregion [抽出処理]

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <param name="paramWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private int DevSalesDayMonthReport(CampaignRsltList campaignRsltList, out CampaignstRsltListPrtWork paramWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            paramWork = new CampaignstRsltListPrtWork();

            try
            {
                paramWork.TotalType = (int)campaignRsltList.TotalType;                   // 集計単位(0:商品別 1:得意先別 2:担当者別)
                paramWork.EnterpriseCode = campaignRsltList.EnterpriseCode;              // 企業コード
                paramWork.CampaignCode = campaignRsltList.CampaignCode;                  // キャンペーンコード
                paramWork.SectionCodes = campaignRsltList.SectionCodes;                  // 拠点コード
                paramWork.ApplyStaDate = campaignRsltList.ApplyStaDate;                  // 適用開始日
                paramWork.ApplyEndDate = campaignRsltList.ApplyEndDate;                  // 適用終了日

                paramWork.PrintType = campaignRsltList.PrintType;                        // 印刷タイプ

                paramWork.AddUpYearMonthSt = campaignRsltList.AddUpYearMonthSt;          // 開始対象年月
                paramWork.AddUpYearMonthEd = campaignRsltList.AddUpYearMonthEd;          // 終了対象年月
                paramWork.AddUpYearMonthDaySt = campaignRsltList.AddUpYearMonthDaySt;    // 開始対象年月
                paramWork.AddUpYearMonthDayEd = campaignRsltList.AddUpYearMonthDayEd;    // 終了対象年月

                paramWork.Detail = campaignRsltList.Detail;                              // 明細単位
                paramWork.Total = campaignRsltList.Total;                                // 小計単位
                paramWork.OutputSort = campaignRsltList.OutputSort;                      // 出力順

                paramWork.EmployeeCodeSt = campaignRsltList.EmployeeCodeSt;              // 開始担当者
                paramWork.EmployeeCodeEd = campaignRsltList.EmployeeCodeEd;              // 終了担当者

                paramWork.AcceptOdrCodeSt = campaignRsltList.AcceptOdrCodeSt;            // 開始受注者
                paramWork.AcceptOdrCodeEd = campaignRsltList.AcceptOdrCodeEd;            // 終了受注者

                paramWork.PrinterCodeSt = campaignRsltList.PrinterCodeSt;                // 開始発行者
                paramWork.PrinterCodeEd = campaignRsltList.PrinterCodeEd;                // 終了発行者

                paramWork.CustomerCodeSt = campaignRsltList.CustomerCodeSt;              // 得意先コード
                paramWork.CustomerCodeEd = campaignRsltList.CustomerCodeEd;              // 得意先コード

                paramWork.AreaCodeSt = campaignRsltList.AreaCodeSt;                      // 地区開始コード
                paramWork.AreaCodeEd = campaignRsltList.AreaCodeEd;                      // 地区終了コード

                paramWork.GoodsMakerCdSt = campaignRsltList.GoodsMakerCdSt;　　　　　　　// 開始商品メーカー
                paramWork.GoodsMakerCdEd = campaignRsltList.GoodsMakerCdEd;　　　　　　　// 終了商品メーカー

                paramWork.GoodsNoSt = campaignRsltList.GoodsNoSt;                        // 開始品番
                paramWork.GoodsNoEd = campaignRsltList.GoodsNoEd;                        // 終了品番

                paramWork.BLGoodsCodeSt = campaignRsltList.BLGoodsCodeSt;                // 開始BLコード
                paramWork.BLGoodsCodeEd = campaignRsltList.BLGoodsCodeEd;                // 終了BLコード

                paramWork.BLGroupCodeSt = campaignRsltList.BLGroupCodeSt;                // 開始グループコード
                paramWork.BLGroupCodeEd = campaignRsltList.BLGroupCodeEd;                // 終了グループコード

                paramWork.SalesCodeSt = campaignRsltList.SalesCodeSt;                    // 開始販売区分コード
                paramWork.SalesCodeEd = campaignRsltList.SalesCodeEd;                    // 終了販売区分コード
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 売上データの合計
        /// </summary>
        /// <param name="salesList">取得の売上データ</param>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <param name="resultLst">結果データ</param>
        /// <remarks>
        /// <br>Note       : 売上データの合計を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// <br>Update Note: 2011/07/27 高峰</br>
        /// <br>           : Redmine 障害報告 #23232 の対応</br>
        /// <br>Update Note: 2011/08/03 yangmj</br>
        /// <br>           : Redmine 障害報告 #23232 の対応</br>
        /// </remarks>
        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
        //private void SumSalesData(ArrayList salesList, CampaignRsltList campaignRsltList, ref ArrayList resultLst)
        private void SumSalesData(ArrayList salesList, CampaignRsltList campaignRsltList, ref ArrayList dataList)
        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
        {
            string workKey = string.Empty;
            string compKey = string.Empty;
            string makerCode = string.Empty;
            CampaignstRsltListResultWork work = new CampaignstRsltListResultWork();
            int monthCnt = GetTermMonthCount(campaignRsltList);
            Dictionary<string, DateTerm> dic = new Dictionary<string,DateTerm>();
            ArrayList resultLst = new ArrayList(); // ADD 2011/07/27

            // 印刷タイプ：期間
            if (campaignRsltList.PrintType == 1)
            {
                DateTime monthSt = campaignRsltList.AddUpYearMonthSt;

                while (monthSt <= campaignRsltList.AddUpYearMonthEd)
                {
                    DateTime startDate = DateTime.MinValue;
                    DateTime endDate = DateTime.MinValue;
                    this._dateGet.GetDaysFromMonth(monthSt, out startDate, out endDate);

                    if (TDateTime.DateTimeToLongDate(endDate) < campaignRsltList.ApplyStaDate || TDateTime.DateTimeToLongDate(startDate) > campaignRsltList.ApplyEndDate)
                    {
                        monthSt = monthSt.AddMonths(1);
                        continue;
                    }

                    // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                    //if (TDateTime.DateTimeToLongDate(startDate) < campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(endDate) > campaignRsltList.ApplyStaDate)
                    if (TDateTime.DateTimeToLongDate(startDate) <= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(endDate) >= campaignRsltList.ApplyStaDate)
                    // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                    {
                        startDate = TDateTime.LongDateToDateTime(campaignRsltList.ApplyStaDate);
                    }
                    // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                    //if (TDateTime.DateTimeToLongDate(startDate) < campaignRsltList.ApplyEndDate && TDateTime.DateTimeToLongDate(endDate) > campaignRsltList.ApplyEndDate)
                    if (TDateTime.DateTimeToLongDate(startDate) <= campaignRsltList.ApplyEndDate && TDateTime.DateTimeToLongDate(endDate) >= campaignRsltList.ApplyEndDate)
                    // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                    {
                        endDate = TDateTime.LongDateToDateTime(campaignRsltList.ApplyEndDate);
                    }

                    DateTerm dateTerm = new DateTerm();
                    dateTerm.DateTimeSt = startDate;
                    dateTerm.DateTimeEd = endDate;

                    dic.Add(monthSt.Month.ToString(), dateTerm);
                    monthSt = monthSt.AddMonths(1);
                }
            }

            foreach (CampaignstRsltListResultWork camWork in salesList)
            {
                // ----- ADD 2011/07/27 ----- >>>>>
                if (camWork.SalesSlipCdDtl == 2 && camWork.GoodsNo == string.Empty)
                {
                    continue;
                }
                // ----- ADD 2011/07/27 ----- <<<<<

                if (campaignRsltList.PrintType != 1)
                {
                    makerCode = camWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                }

                switch (campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods:
                        {
                            #region 商品別
                            #region Keyの作成
                            // 明細単位
                            if (campaignRsltList.Detail == 0)
                            {
                                // 小計単位
                                if (campaignRsltList.Total == 0)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                            }
                            else if (campaignRsltList.Detail == 1)
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            else
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            #endregion

                            #region 合計
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());
                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // 当月合計
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // 期間合計
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {

                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // 印刷タイプ：当月/日付
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // 印刷タイプ：期間
                            else
                            {
                                // ----- UPD 2011/07/27 --------------------------->>>>>
                                //if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                if (compKey != workKey && CheckMonthValue(monthCnt, work))
                                // ----- UPD 2011/07/27 ---------------------------<<<<<
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachCustomer:
                        {
                            #region 得意先別
                            #region Keyの作成
                            // 出力順
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else if (campaignRsltList.OutputSort == 1)
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            #endregion

                            #region 合計
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // 当月合計
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // 期間合計
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {

                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // 印刷タイプ：当月/日付
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // 印刷タイプ：期間
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachEmployee:
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr:
                    case CampaignRsltList.TotalTypeState.EachPrinter:
                        {
                            #region 担当者別・受注者別・発行者別
                            #region Keyの作成
                            // 出力順
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else if (campaignRsltList.OutputSort == 1)
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            #endregion

                            #region 合計
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }

                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // 当月合計
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // 期間合計
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {

                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // 印刷タイプ：当月/日付
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // 印刷タイプ：期間
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachArea:
                        {
                            #region 地区別
                            #region Keyの作成
                            // 出力順
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else if (campaignRsltList.OutputSort == 1)
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else
                            {
                                // 明細単位
                                if (campaignRsltList.Detail == 0)
                                {
                                    // 小計単位
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            #endregion

                            #region 合計
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }

                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // 当月合計
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // 期間合計
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // 印刷タイプ：当月/日付
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27

                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // 印刷タイプ：期間
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachSales:
                        {
                            #region 販売区分別
                            #region Keyの作成
                            // 明細単位
                            if (campaignRsltList.Detail == 0)
                            {
                                // 小計単位
                                if (campaignRsltList.Total == 0)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                            }
                            else if (campaignRsltList.Detail == 1)
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            else
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            #endregion

                            #region 合計
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // 当月合計
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    // 期間合計
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //印刷タイプ：期間
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // 印刷タイプ：当月/日付
                            if (campaignRsltList.PrintType != 1)
                            {
                                // if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // 印刷タイプ：期間
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                }

            }

            // ----- ADD 2011/07/27 ------------------------------------------->>>>>
            foreach (CampaignstRsltListResultWork resultwork in resultLst)
            {
                // 印刷タイプ：当月/日付
                if (campaignRsltList.PrintType != 1)
                {
                    if (resultwork.AddUpShipmentCnt != 0 || resultwork.CampaignShipmentCnt != 0 || resultwork.AddUpSalesMoneyTaxExc != 0
                        || resultwork.CampaignSalesMoneyTaxExc != 0 || resultwork.AddUpSalesProfit != 0 || resultwork.CampaignSalesProfit != 0)
                    {
                        dataList.Add(resultwork);
                    }
                }
                // 印刷タイプ：期間
                else
                {
                    if (CheckMonthValue(monthCnt, resultwork))
                    {
                        dataList.Add(resultwork);
                    }
                }
            }
            // ----- ADD 2011/07/27 -------------------------------------------<<<<<
        }

        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <param name="salesList">取得の売上データ</param>
        /// <param name="targetList">取得の目標データ</param>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <param name="resultLst">結果データ</param>
        /// <remarks>
        /// <br>Note       : データ抽出処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void SetDataFrmTargetToSales(ArrayList salesList, ArrayList targetList, CampaignRsltList campaignRsltList, out ArrayList resultLst)
        {
            string dicKey = string.Empty;
            string workSec = string.Empty;
            string secCode = string.Empty;// 拠点用
            string section = string.Empty; // 担当者用
            string employee = string.Empty;
            int customer = 0;
            string groupGoodsCode = string.Empty;
            string area = string.Empty;
            int index = 0;
            string section1 = string.Empty; // 小計用
            string section2 = string.Empty; // 拠点計用

            // 目標値の取得・算出
            if (salesList.Count != 0 && targetList.Count != 0)
            {
                GetTargetDate(targetList, campaignRsltList);

                // 実績用のリストのセット方法
                foreach (CampaignstRsltListResultWork camWork in salesList)
                {
                    switch (campaignRsltList.TotalType)
                    {
                        case CampaignRsltList.TotalTypeState.EachGoods: //商品別
                            {
                                #region ●商品別
                                //小計用
                                #region
                                string subTotalCode = string.Empty;
                                // 小計単位:「0:ｸﾞﾙｰﾌﾟｺｰﾄﾞ」場合
                                if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2)
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode;
                                    subTotalCode = camWork.BLGroupCode.ToString();
                                }
                                else if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1)
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode;
                                    subTotalCode = camWork.BLGoodsCode.ToString();
                                }

                                if ((campaignRsltList.PrintType != 1 && campaignRsltList.Detail == 0) || campaignRsltList.PrintType == 1)
                                {
                                    if (section != camWork.ResultsAddUpSecCd || groupGoodsCode != subTotalCode)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;

                                            section = camWork.ResultsAddUpSecCd;
                                            // 小計単位:「0:ｸﾞﾙｰﾌﾟｺｰﾄﾞ」場合
                                            if (campaignRsltList.Total == 0)
                                            {
                                                groupGoodsCode = camWork.BLGroupCode.ToString();
                                            }
                                            else
                                            {
                                                groupGoodsCode = camWork.BLGoodsCode.ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                        camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                        camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                        camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                        camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                        camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;                                        
                                    }
                                }
                                #endregion

                                // 拠点計用
                                #region
                                if (index == 0)
                                {
                                    section2 = string.Empty;
                                }
                                dicKey = camWork.ResultsAddUpSecCd;

                                if (section2 != camWork.ResultsAddUpSecCd)
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                        camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                        camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                        camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                        camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                        camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;

                                        section2 = camWork.ResultsAddUpSecCd;
                                    }
                                }
                                #endregion

                                index++;
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                            {
                                #region ●得意先別
                                // 出力順が「得意先」「管理拠点」の場合
                                if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 3)
                                {
                                    if (campaignRsltList.OutputSort == 3)
                                    {
                                        workSec = camWork.ManageSectionCode;
                                    }
                                    else
                                    {
                                        workSec = camWork.ResultsAddUpSecCd;
                                    }
                                    // 得意先計
                                    // キー = 拠点・得意先
                                    dicKey = workSec + camWork.CustomerCode.ToString().PadLeft(8, '0');

                                    if (section != workSec || customer != camWork.CustomerCode)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget3 = this._totalDic[dicKey].MonthlySalesTarget3;
                                            camWork.MonthlySalesTargetProfit3 = this._totalDic[dicKey].MonthlySalesTargetProfit3;
                                            camWork.MonthlySalesTargetCount3 = this._totalDic[dicKey].MonthlySalesTargetCount3;

                                            camWork.TermSalesTarget3 = this._totalDic[dicKey].TermSalesTarget3;
                                            camWork.TermSalesTargetProfit3 = this._totalDic[dicKey].TermSalesTargetProfit3;
                                            camWork.TermSalesTargetCount3 = this._totalDic[dicKey].TermSalesTargetCount3;
                                        }

                                        section = workSec;
                                        customer = camWork.CustomerCode;
                                    }
                                    // 拠点計
                                    // キー = 拠点ｺｰﾄﾞ
                                    dicKey = workSec;

                                    if (secCode != workSec)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = workSec;
                                    }
                                }
                                // 出力順が「拠点」の場合
                                else if (campaignRsltList.OutputSort == 1)
                                {
                                    // 拠点計
                                    // キー = 拠点
                                    dicKey = camWork.ResultsAddUpSecCd;

                                    if (secCode != camWork.ResultsAddUpSecCd)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = camWork.ResultsAddUpSecCd;
                                    }
                                    //小計用
                                    string subTotalCode = string.Empty;
                                    // 小計単位:「0:ｸﾞﾙｰﾌﾟｺｰﾄﾞ」場合
                                    if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2)
                                    {
                                        dicKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0');
                                        subTotalCode = camWork.BLGroupCode.ToString();
                                    }
                                    else if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1)
                                    {
                                        dicKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0');
                                        subTotalCode = camWork.BLGoodsCode.ToString();
                                    }

                                    if ((campaignRsltList.PrintType != 1 && campaignRsltList.Detail == 0) || campaignRsltList.PrintType == 1)
                                    {
                                        if (section != camWork.ResultsAddUpSecCd || groupGoodsCode != subTotalCode)
                                        {
                                            if (this._totalDic.ContainsKey(dicKey))
                                            {
                                                camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                                camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                                camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                                camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                                camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                                camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                            }

                                            section = camWork.ResultsAddUpSecCd;
                                            // 小計単位:「0:ｸﾞﾙｰﾌﾟｺｰﾄﾞ」場合
                                            if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2)
                                            {
                                                groupGoodsCode = camWork.BLGroupCode.ToString();
                                            }
                                            else if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1)
                                            {
                                                groupGoodsCode = camWork.BLGoodsCode.ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }
                                    }
                                }
                                // 出力順が「得意先－拠点」の場合
                                else if (campaignRsltList.OutputSort == 2)
                                {
                                    // キー = 得意先・拠点
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0');

                                    if (section != camWork.ResultsAddUpSecCd || customer != camWork.CustomerCode)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget3;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit3;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount3;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget3;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit3;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount3;
                                        }

                                        section = camWork.ResultsAddUpSecCd;
                                        customer = camWork.CustomerCode;
                                    }
                                }
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                        case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                        case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                            {
                                #region ●担当者別・発行者別・受注者別
                                // 出力順が「担当者/発行者/受注者」「得意先」「管理拠点」の場合
                                if (campaignRsltList.OutputSort != 2)
                                {
                                    if (campaignRsltList.OutputSort == 3)
                                    {
                                        workSec = camWork.ManageSectionCode;
                                    }
                                    else
                                    {
                                        workSec = camWork.ResultsAddUpSecCd;
                                    }

                                    // 担当者用
                                    dicKey = workSec + camWork.SalesEmployeeCd;

                                    if (section != workSec || employee != camWork.SalesEmployeeCd)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = workSec;
                                        employee = camWork.SalesEmployeeCd;
                                    }
                                    // 拠点用
                                    dicKey = workSec;

                                    if (secCode != workSec)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = workSec;
                                    }
                                }
                                // 出力順が「担当者－拠点/発行者－拠点/受注者－拠点」の場合
                                else
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;

                                    if (section != camWork.ResultsAddUpSecCd || employee != camWork.SalesEmployeeCd)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = camWork.ResultsAddUpSecCd;
                                        employee = camWork.SalesEmployeeCd;
                                    }
                                }
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                            {
                                #region ●地区別
                                // 出力順が「地区」「得意先」「管理拠点」の場合
                                if (campaignRsltList.OutputSort != 2)
                                {
                                    if (campaignRsltList.OutputSort == 3)
                                    {
                                        workSec = camWork.ManageSectionCode;
                                    }
                                    else
                                    {
                                        workSec = camWork.ResultsAddUpSecCd;
                                    }

                                    // 地区用
                                    dicKey = workSec + camWork.SalesAreaCode;

                                    if (section != workSec || area != camWork.SalesAreaCode.ToString())
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = workSec;
                                        area = camWork.SalesAreaCode.ToString();
                                    }
                                    // 拠点用
                                    dicKey = workSec;

                                    if (secCode != workSec)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = workSec;
                                    }
                                }
                                // 出力順が「地区－拠点」の場合
                                else
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode;

                                    if (section != camWork.ResultsAddUpSecCd || area != camWork.SalesAreaCode.ToString())
                                    {
                                        if (_totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = camWork.ResultsAddUpSecCd;
                                        area = camWork.SalesAreaCode.ToString();
                                    }
                                }
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachSales: // 販売区分
                            {
                                #region ●販売区分別
                                // 販売区分
                                dicKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;

                                if (section != camWork.ResultsAddUpSecCd || employee != camWork.SalesEmployeeCd)
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                        camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                        camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                        camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                        camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                        camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                    }

                                    section = camWork.ResultsAddUpSecCd;
                                    employee = camWork.SalesEmployeeCd;
                                }
                                // 拠点用
                                dicKey = camWork.ResultsAddUpSecCd;

                                if (secCode != camWork.ResultsAddUpSecCd)
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                        camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                        camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                        camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                        camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                        camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                    }

                                    secCode = camWork.ResultsAddUpSecCd;
                                }
                                #endregion
                            }
                            break;
                    }
                }
            }
            resultLst = salesList;
        }

        #region [目標値の取得・算出]
        /// <summary>
        /// 目標値の取得・算出
        /// </summary>
        /// <param name="list">取得データ</param>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : データ抽出処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void GetTargetDate(ArrayList list, CampaignRsltList campaignRsltList)
        {
            DateTime startDate = campaignRsltList.AddUpYearMonthSt;
            DateTime endDate = campaignRsltList.AddUpYearMonthEd;

            // 対象日付の月数
            int month = 0;
            ArrayList monthlist = new ArrayList();
            while (startDate <= endDate) 
            {
                monthlist.Add(startDate.Month);
                startDate = startDate.AddMonths(1);
            }
            month = monthlist.Count;

            // 月間目標
            long monthlySalesTarget = 0;
            long monthlySalesTargetProfit = 0;
            double monthlySalesTargetCount = 0;
            // 期間目標
            long termSalesTarget = 0;
            long termSalesTargetProfit = 0;
            double termSalesTargetCount = 0;

            string workKey = string.Empty; 

            foreach (CampaignstRsltListResultWork camWork in list)
            {
                monthlySalesTarget = 0;
                monthlySalesTargetProfit = 0;
                monthlySalesTargetCount = 0;

                // 月間目標
                if (campaignRsltList.PrintType == 0)
                {
                    // 売上月間目標金額                
                    if (camWork.MonthlySalesTarget != 0)
                    {
                        monthlySalesTarget = camWork.MonthlySalesTarget * month;
                    }
                    else
                    {
                        // 対象日付の範囲に該当する月別の目標値の累計
                        for (int ix = 1; ix < 13; ix++) 
                        {
                            if (monthlist.Contains(ix))
                            {
                                long salesTargetMoney = 0;
                                salesTargetMoney = this.GetLongPropertyValueFromObject(camWork, ctSalesTargetMoney + ix);
                                if (salesTargetMoney != 0)
                                {
                                    monthlySalesTarget += salesTargetMoney;
                                }
                            }
                        }
                    }
                    // 売上月間目標粗利額
                    if (camWork.MonthlySalesTargetProfit != 0)
                    {
                        monthlySalesTargetProfit = camWork.MonthlySalesTargetProfit * month;
                    }
                    else
                    {
                        // 対象日付の範囲に該当する月別の目標値の累計
                        for (int ix = 1; ix < 13; ix++)
                        {
                            if (monthlist.Contains(ix))
                            {
                                long salesTargetProfit = this.GetLongPropertyValueFromObject(camWork, ctSalesTargetProfit + ix);
                                if (salesTargetProfit != 0)
                                {
                                    monthlySalesTargetProfit += salesTargetProfit;
                                }
                            }
                        }
                    }
                    // 売上月間目標数量
                    if (camWork.MonthlySalesTargetCount != 0)
                    {
                        monthlySalesTargetCount = camWork.MonthlySalesTargetCount * month;
                    }
                    else
                    {
                        // 対象日付の範囲に該当する月別の目標値の累計
                        for (int ix = 1; ix < 13; ix++)
                        {
                            if (monthlist.Contains(ix))
                            {
                                double salesTargetCount = this.GetDoublePropertyValueFromObject(camWork, ctSalesTargetCount + ix);
                                if (salesTargetCount != 0)
                                {
                                    monthlySalesTargetCount += salesTargetCount;
                                }
                            }
                        }
                    }
                }

                // 期間目標
                // 売上期間目標金額                
                if (camWork.TermSalesTarget != 0)
                {
                    termSalesTarget = camWork.TermSalesTarget;
                }
                else
                {
                    termSalesTarget = camWork.SalesTargetMoney1 +
                                      camWork.SalesTargetMoney2 +
                                      camWork.SalesTargetMoney3 +
                                      camWork.SalesTargetMoney4 +
                                      camWork.SalesTargetMoney5 +
                                      camWork.SalesTargetMoney6 +
                                      camWork.SalesTargetMoney7 +
                                      camWork.SalesTargetMoney8 +
                                      camWork.SalesTargetMoney9 +
                                      camWork.SalesTargetMoney10 +
                                      camWork.SalesTargetMoney11 +
                                      camWork.SalesTargetMoney12;
                }
                // 売上期間目標粗利額
                if (camWork.TermSalesTargetProfit != 0)
                {
                    termSalesTargetProfit = camWork.TermSalesTargetProfit;
                }
                else
                {
                    termSalesTargetProfit = camWork.SalesTargetProfit1 +
                                            camWork.SalesTargetProfit2 +
                                            camWork.SalesTargetProfit3 +
                                            camWork.SalesTargetProfit4 +
                                            camWork.SalesTargetProfit5 +
                                            camWork.SalesTargetProfit6 +
                                            camWork.SalesTargetProfit7 +
                                            camWork.SalesTargetProfit8 +
                                            camWork.SalesTargetProfit9 +
                                            camWork.SalesTargetProfit10 +
                                            camWork.SalesTargetProfit11 +
                                            camWork.SalesTargetProfit12;
                }
                // 売上期間目標数量
                if (camWork.TermSalesTargetCount != 0)
                {
                    termSalesTargetCount = camWork.TermSalesTargetCount;
                }
                else
                {
                    termSalesTargetCount = camWork.SalesTargetCount1 +
                                           camWork.SalesTargetCount2 +
                                           camWork.SalesTargetCount3 +
                                           camWork.SalesTargetCount4 +
                                           camWork.SalesTargetCount5 +
                                           camWork.SalesTargetCount6 +
                                           camWork.SalesTargetCount7 +
                                           camWork.SalesTargetCount8 +
                                           camWork.SalesTargetCount9 +
                                           camWork.SalesTargetCount10 +
                                           camWork.SalesTargetCount11 +
                                           camWork.SalesTargetCount12;
                }

                this._dictionaryCampTarget = new CampaignTargetValue();
                
                switch (campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                        {
                            #region ●商品別
                            // 小計用
                            if (camWork.TargetContrastCd == 60 || camWork.TargetContrastCd == 50)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                //小計単位:「0：ｸﾞﾙｰﾌﾟｺｰﾄ」場合
                                if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2) && camWork.TargetContrastCd == 50)
                                {
                                    // 拠点・ｸﾞﾙｰﾌﾟｺｰﾄ
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode;
                                }
                                // 目標対比区分:60「拠点・BLｺｰﾄﾞ」の場合
                                else if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1) && camWork.TargetContrastCd == 60)
                                {
                                    // 拠点・BLﾟｺｰﾄ
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode;
                                }
                                else
                                {
                                    workKey = string.Empty;
                                }

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // 拠点用
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // 拠点ｺｰﾄﾞ
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                        {
                            #region ●得意先別
                            // 小計用
                            if (camWork.TargetContrastCd == 60 || camWork.TargetContrastCd == 50)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // 目標対比区分:50「拠点＋ｸﾞﾙｰﾌﾟｺｰﾄﾞ」の場合
                                if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2) && camWork.TargetContrastCd == 50)
                                {
                                    // 拠点・ｸﾞﾙｰﾌﾟｺｰﾄ
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0');
                                }
                                // 目標対比区分:60「拠点・BLｺｰﾄﾞ」の場合
                                else if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1) && camWork.TargetContrastCd == 60)
                                {
                                    // 拠点・BLﾟｺｰﾄ
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0');
                                }
                                else
                                {
                                    workKey = string.Empty;
                                }

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // 得意先用
                            else if (camWork.TargetContrastCd == 30)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget3 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit3 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount3 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget3 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit3 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount3 = termSalesTargetCount;

                                // 拠点・得意先
                                workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0');

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // 拠点用
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // 拠点ｺｰﾄﾞ
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                    case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                        {
                            #region ●担当者別・受注者別・発行者別
                            // 担当者用/受注者/発行者用
                            if (camWork.TargetContrastCd == 22)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // 拠点・担当者/受注者/発行者
                                workKey = camWork.ResultsAddUpSecCd + camWork.EmployeeCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // 拠点用
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // 拠点ｺｰﾄﾞ
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                        {
                            #region ●地区別
                            // 地区用
                            if (camWork.TargetContrastCd == 32)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // 拠点・地区
                                workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // 拠点用
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // 拠点ｺｰﾄﾞ
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachSales:
                        {
                            #region ●販売区分別
                            // 販売区分用
                            if (camWork.TargetContrastCd == 44)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // 拠点・販売区分
                                workKey = camWork.ManageSectionCode + camWork.EmployeeCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // 拠点用
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // 月間目標
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // 期間目標
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // 拠点ｺｰﾄﾞ
                                workKey = camWork.ManageSectionCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                }
            }
        }
        #endregion [目標値の取得・算出]

        #region [プロパティ値の算出]
        /// <summary>
        /// 指定されたオブジェクトのlongプロパティの値取得
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="propertyName">プロパティ名称</param>
        /// <remarks>
        /// <br>Note　　　  : 指定されたオブジェクトのlongプロパティ値取得</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private long GetLongPropertyValueFromObject(object obj, string propertyName)
        {
            // 戻り値定義
            long result = 0;

            // プロパティ値取得
            object retVal = GetPropertyValueFromObject(obj, propertyName);

            // データ有効性チェック
            if (retVal != null && retVal is long)
            {
                result = Convert.ToInt64(retVal);
            }

            return result;
        }

        /// <summary>
        /// 指定されたオブジェクトのlongプロパティの値取得
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="propertyName">プロパティ名称</param>
        /// <remarks>
        /// <br>Note　　　  : 指定されたオブジェクトのlongプロパティ値取得</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private double GetDoublePropertyValueFromObject(object obj, string propertyName)
        {
            // 戻り値定義
            double result = 0;

            // プロパティ値取得
            object retVal = GetPropertyValueFromObject(obj, propertyName);

            // データ有効性チェック
            if (retVal != null && retVal is double)
            {
                result = Convert.ToDouble(retVal);
            }

            return result;
        }

        /// <summary>
        /// 指定されたオブジェクトのプロパティの値取得
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="propertyName">プロパティ名称</param>
        /// <remarks>
        /// <br>Note　　　  : 指定されたオブジェクトのintプロパティ値取得</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private object GetPropertyValueFromObject(object obj, string propertyName)
        {
            // 戻り値定義
            object result = null;

            // NULLチェック
            if (obj != null && propertyName != null && !String.IsNullOrEmpty(propertyName))
            {
                // 金種コードプロパティ取得
                PropertyInfo propInfo = obj.GetType().GetProperty(propertyName);

                // NULLチェック
                if (propInfo != null)
                {
                    // プロパティ値取得
                    result = propInfo.GetValue(obj, null);
                }
            }

            return result;
        }

        /// <summary>
        /// 月数の算出
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>期間月分</returns>
        /// <remarks>
        /// <br>Note       : 月数の算出を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private int GetTermMonthCount(CampaignRsltList campaignRsltList)
        {
            DateTime startDate = campaignRsltList.AddUpYearMonthSt;
            DateTime endDate = campaignRsltList.AddUpYearMonthEd;

            // 対象日付の月数
            int month = 0;
            ArrayList monthlist = new ArrayList();
            while (startDate <= endDate)
            {
                monthlist.Add(startDate.Month);
                startDate = startDate.AddMonths(1);
            }
            month = monthlist.Count;
            return month;
        }

        /// <summary>
        /// チェック
        /// </summary>
        /// <param name="monthCnt">月数</param>
        /// <param name="camWork">売上データ</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : データ抽出処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private bool CheckMonthValue(int monthCnt, CampaignstRsltListResultWork camWork)
        {
            bool isTargetData = false;

            for (int i = 1; i <= monthCnt; i++)
            {
                if ((long)GetPropertyValueFromObject(camWork, "SalesMoneyTaxExc" + i.ToString()) != 0
                    || (long)GetPropertyValueFromObject(camWork, "SalesProfit" + i.ToString()) != 0
                    //|| (double)GetPropertyValueFromObject(camWork, "SalesTargetCount" + i.ToString()) != 0)
                    || (double)GetPropertyValueFromObject(camWork, "TotalSalesCount" + i.ToString()) != 0)
                {
                    isTargetData = true;
                    break;
                }
            }
            return isTargetData;
        }
        #endregion

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <param name="list">取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データ展開処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void DevStockMoveData(CampaignRsltList campaignRsltList, ArrayList list)
        {
            DataRow dr;
            string applyDate = string.Empty;
            string headerKey = string.Empty;

            applyDate = "[ " + campaignRsltList.ApplyStaDate.ToString("####/##/##") + " ～ " + campaignRsltList.ApplyEndDate.ToString("####/##/##") + " ]";
            
            foreach (CampaignstRsltListResultWork camWork in list)
            {
                dr = this._campaignRsltListDt.NewRow();
                dr[PMKHN02054EA.ct_Col_ApplyDate]           = applyDate;                    // ｷｬﾝﾍﾟｰﾝ適用日
                dr[PMKHN02054EA.ct_Col_CampaignCode]        = camWork.CampaignCode;         // ｷｬﾝﾍﾟｰﾝ
                dr[PMKHN02054EA.ct_Col_CampaignName]        = camWork.CampaignName;         // ｷｬﾝﾍﾟｰﾝ名称

                switch (campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                    case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                    case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                    {
                        // 画面の出力順が「担当者」「得意先」「担当者-拠点」/「地区」「得意先」「地区-拠点」の場合
                        if (campaignRsltList.OutputSort != 3)
                        {
                            // 実績計上拠点コード
                            dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                            // 拠点名称
                            if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "未登録";
                            }

                            // 出力順が「得意先」の場合
                            if (campaignRsltList.OutputSort == 1)
                            {
                                // 得意先コード
                                dr[PMKHN02054EA.ct_Col_CustomerCode] = camWork.CustomerCode;
                                // 得意先名称
                                if (!string.IsNullOrEmpty(camWork.CustomerSnm))
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = camWork.CustomerSnm;
                                }
                                else
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = "未登録";
                                }                                
                            }
                            else
                            {
                                switch (campaignRsltList.TotalType)
                                {
                                    case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                                    case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                                        {
                                            headerKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;
                                        }
                                        break;
                                    case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                                        {
                                            headerKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode;
                                        }
                                        break;
                                }
                                dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                            }
                            
                            
                        }
                        // 画面の出力順が「管理拠点」の場合
                        else
                        {
                            // 管理拠点コード
                            dr[PMKHN02054EA.ct_Col_ManageSectionCode] = camWork.ManageSectionCode;
                            // 拠点名称
                            if (!string.IsNullOrEmpty(camWork.ManageSectionSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = camWork.ManageSectionSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = "未登録";
                            }
                            switch (campaignRsltList.TotalType)
                            {
                                case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                                case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                                    {
                                        headerKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd;
                                    }
                                    break;
                                case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                                    {
                                        headerKey = camWork.ManageSectionCode + camWork.SalesAreaCode;
                                    }
                                    break;
                            }
                            dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                        }
                        break;
                    }

                    case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    {
                        // 実績計上拠点コード
                        dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                        // 拠点名称
                        if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                        }
                        else
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "未登録";
                        }
                        break;
                    }

                    case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                    {
                        // 画面の出力順が「得意先」「拠点」「得意先-拠点」の場合
                        if (campaignRsltList.OutputSort != 3)
                        {
                            // 実績計上拠点コード
                            dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                            // 拠点名称
                            if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "未登録";
                            }

                            // 出力順が「得意先」/「得意先-拠点」の場合
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // 得意先コード
                                dr[PMKHN02054EA.ct_Col_CustomerCode] = camWork.CustomerCode;
                                // 得意先名称
                                if (!string.IsNullOrEmpty(camWork.CustomerSnm))
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = camWork.CustomerSnm;
                                }
                                else
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = "未登録";
                                }
                                headerKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode;
                                dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                            }

                        }
                        // 画面の出力順が「管理拠点」の場合
                        else
                        {
                            // 管理拠点コード
                            dr[PMKHN02054EA.ct_Col_ManageSectionCode] = camWork.ManageSectionCode;
                            // 拠点名称
                            if (!string.IsNullOrEmpty(camWork.ManageSectionSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = camWork.ManageSectionSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = "未登録";
                            }
                            // 得意先コード
                            dr[PMKHN02054EA.ct_Col_CustomerCode] = camWork.CustomerCode;
                            // 得意先名称
                            if (!string.IsNullOrEmpty(camWork.CustomerSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_CustomerSnm] = camWork.CustomerSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_CustomerSnm] = "未登録";
                            }
                            headerKey = camWork.ManageSectionCode + camWork.CustomerCode;
                            dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                        }
                        break;
                    }

                    case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                    {
                        // 実績計上拠点コード
                        dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                        // 拠点名称
                        if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                        }
                        else
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "未登録";
                        }

                        // 販売区分
                        dr[PMKHN02054EA.ct_Col_EmployeeCode] = camWork.SalesEmployeeCd;
                        // 販売区分名称
                        if (!string.IsNullOrEmpty(camWork.EmployeeName))
                        {
                            dr[PMKHN02054EA.ct_Col_EmployeeName] = camWork.EmployeeName;
                        }
                        else
                        {
                            dr[PMKHN02054EA.ct_Col_EmployeeName] = "未登録";
                        }

                        headerKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;
                        dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                        break;
                    }
                }
                // 担当者
                dr[PMKHN02054EA.ct_Col_EmployeeCode]        = camWork.SalesEmployeeCd;
                // 担当者名称
                if (!string.IsNullOrEmpty(camWork.EmployeeName))
                {
                    dr[PMKHN02054EA.ct_Col_EmployeeName] = camWork.EmployeeName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_EmployeeName] = "未登録";
                }                
                // 地区コード
                dr[PMKHN02054EA.ct_Col_AreaCode] = camWork.SalesAreaCode;
                // 地区名称
                if (!string.IsNullOrEmpty(camWork.GuideName))
                {
                    dr[PMKHN02054EA.ct_Col_AreaName] = camWork.GuideName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_AreaName] = "未登録";
                }

                // BLグループコード
                dr[PMKHN02054EA.ct_Col_BLGroupCode] = camWork.BLGroupCode;
                // BLグループコード名称
                if (!string.IsNullOrEmpty(camWork.BLGroupKanaName))
                {
                    dr[PMKHN02054EA.ct_Col_BLGroupKanaName] = camWork.BLGroupKanaName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_BLGroupKanaName] = "未登録";
                }

                // BL商品コード
                dr[PMKHN02054EA.ct_Col_BLGoodsCode] = camWork.BLGoodsCode;
                // BL商品コード名称
                if (!string.IsNullOrEmpty(camWork.BLGoodsHalfName))
                {
                    dr[PMKHN02054EA.ct_Col_BLGoodsHalfName] = camWork.BLGoodsHalfName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_BLGoodsHalfName] = "未登録";
                }

                // 商品番号
                dr[PMKHN02054EA.ct_Col_GoodsNo] = camWork.GoodsNo;
                // 商品名称
                if (!string.IsNullOrEmpty(camWork.GoodsNameKana))
                {
                    dr[PMKHN02054EA.ct_Col_GoodsName] = camWork.GoodsNameKana;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_GoodsName] = "未登録";
                }

                // 商品メーカーコード
                dr[PMKHN02054EA.ct_Col_GoodsMakerCd]        = camWork.GoodsMakerCd;
                // 商品メーカー名称 
                if (!string.IsNullOrEmpty(camWork.MakerName))
                {
                    dr[PMKHN02054EA.ct_Col_MakerShortName] = camWork.MakerName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_MakerShortName] = "未登録";
                }

                // 印刷タイプ：期間
                if (campaignRsltList.PrintType == 1)
                {
                    // 売上数1
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount1] = camWork.TotalSalesCount1;
                    // 売上数2
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount2] = camWork.TotalSalesCount2;
                    // 売上数3
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount3] = camWork.TotalSalesCount3;
                    // 売上数4
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount4] = camWork.TotalSalesCount4;
                    // 売上数5
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount5] = camWork.TotalSalesCount5;
                    // 売上数6
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount6] = camWork.TotalSalesCount6;
                    // 売上数7
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount7] = camWork.TotalSalesCount7;
                    // 売上数8
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount8] = camWork.TotalSalesCount8;
                    // 売上数9
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount9] = camWork.TotalSalesCount9;
                    // 売上数10
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount10] = camWork.TotalSalesCount10;
                    // 売上数11
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount11] = camWork.TotalSalesCount11;
                    // 売上数12
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount12] = camWork.TotalSalesCount12;
                    // 売上金額1
                    dr[PMKHN02054EA.ct_Col_SalesMoney1] = camWork.SalesMoneyTaxExc1;
                    // 売上金額2
                    dr[PMKHN02054EA.ct_Col_SalesMoney2] = camWork.SalesMoneyTaxExc2;
                    // 売上金額3
                    dr[PMKHN02054EA.ct_Col_SalesMoney3] = camWork.SalesMoneyTaxExc3;
                    // 売上金額4
                    dr[PMKHN02054EA.ct_Col_SalesMoney4] = camWork.SalesMoneyTaxExc4;
                    // 売上金額5
                    dr[PMKHN02054EA.ct_Col_SalesMoney5] = camWork.SalesMoneyTaxExc5;
                    // 売上金額6
                    dr[PMKHN02054EA.ct_Col_SalesMoney6] = camWork.SalesMoneyTaxExc6;
                    // 売上金額7
                    dr[PMKHN02054EA.ct_Col_SalesMoney7] = camWork.SalesMoneyTaxExc7;
                    // 売上金額8
                    dr[PMKHN02054EA.ct_Col_SalesMoney8] = camWork.SalesMoneyTaxExc8;
                    // 売上金額9
                    dr[PMKHN02054EA.ct_Col_SalesMoney9] = camWork.SalesMoneyTaxExc9;
                    // 売上金額10
                    dr[PMKHN02054EA.ct_Col_SalesMoney10] = camWork.SalesMoneyTaxExc10;
                    // 売上金額11
                    dr[PMKHN02054EA.ct_Col_SalesMoney11] = camWork.SalesMoneyTaxExc11;
                    // 売上金額12
                    dr[PMKHN02054EA.ct_Col_SalesMoney12] = camWork.SalesMoneyTaxExc12;
                    // 粗利額1
                    dr[PMKHN02054EA.ct_Col_GrossProfit1] = camWork.SalesProfit1;
                    // 粗利額2
                    dr[PMKHN02054EA.ct_Col_GrossProfit2] = camWork.SalesProfit2;
                    // 粗利額3
                    dr[PMKHN02054EA.ct_Col_GrossProfit3] = camWork.SalesProfit3;
                    // 粗利額4
                    dr[PMKHN02054EA.ct_Col_GrossProfit4] = camWork.SalesProfit4;
                    // 粗利額5
                    dr[PMKHN02054EA.ct_Col_GrossProfit5] = camWork.SalesProfit5;
                    // 粗利額6
                    dr[PMKHN02054EA.ct_Col_GrossProfit6] = camWork.SalesProfit6;
                    // 粗利額7
                    dr[PMKHN02054EA.ct_Col_GrossProfit7] = camWork.SalesProfit7;
                    // 粗利額8
                    dr[PMKHN02054EA.ct_Col_GrossProfit8] = camWork.SalesProfit8;
                    // 粗利額9
                    dr[PMKHN02054EA.ct_Col_GrossProfit9] = camWork.SalesProfit9;
                    // 粗利額10
                    dr[PMKHN02054EA.ct_Col_GrossProfit10] = camWork.SalesProfit10;
                    // 粗利額11
                    dr[PMKHN02054EA.ct_Col_GrossProfit11] = camWork.SalesProfit11;
                    // 粗利額12
                    dr[PMKHN02054EA.ct_Col_GrossProfit12] = camWork.SalesProfit12;
                }
                // 当月売上数
                dr[PMKHN02054EA.ct_Col_MonthlySalesCount] = camWork.AddUpShipmentCnt;
                // 期間累計売上数
                dr[PMKHN02054EA.ct_Col_TermSalesCount] = camWork.CampaignShipmentCnt;
                // 当月数量目標1
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetCount1] = camWork.MonthlySalesTargetCount1;
                // 期間累計数量目標1
                dr[PMKHN02054EA.ct_Col_TermSalesTargetCount1] = camWork.TermSalesTargetCount1;
                // 当月数量達成率1
                dr[PMKHN02054EA.ct_Col_MonthlySalesCountAchivRate1] = this.GetRatio(camWork.AddUpShipmentCnt, camWork.MonthlySalesTargetCount1);
                // 期間累計数量達成率1
                dr[PMKHN02054EA.ct_Col_TermSalesCountAchivRate1] = this.GetRatio(camWork.CampaignShipmentCnt, camWork.TermSalesTargetCount1);
                // 当月数量目標2
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetCount2] = camWork.MonthlySalesTargetCount2;
                // 期間累計数量目標2
                dr[PMKHN02054EA.ct_Col_TermSalesTargetCount2] = camWork.TermSalesTargetCount2;
                // 当月数量達成率2
                dr[PMKHN02054EA.ct_Col_MonthlySalesCountAchivRate2] = this.GetRatio(camWork.AddUpShipmentCnt, camWork.MonthlySalesTargetCount2);
                // 期間累計数量達成率2
                dr[PMKHN02054EA.ct_Col_TermSalesCountAchivRate2] = this.GetRatio(camWork.CampaignShipmentCnt, camWork.TermSalesTargetCount2);
                // 当月数量目標3
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetCount3] = camWork.MonthlySalesTargetCount3;
                // 期間累計数量目標3
                dr[PMKHN02054EA.ct_Col_TermSalesTargetCount3] = camWork.TermSalesTargetCount3;
                // 当月数量達成率3
                dr[PMKHN02054EA.ct_Col_MonthlySalesCountAchivRate3] = this.GetRatio(camWork.AddUpShipmentCnt, camWork.MonthlySalesTargetCount3);
                // 期間累計数量達成率3
                dr[PMKHN02054EA.ct_Col_TermSalesCountAchivRate3] = this.GetRatio(camWork.CampaignShipmentCnt, camWork.TermSalesTargetCount3);

                // 当月売上額
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoney] = camWork.AddUpSalesMoneyTaxExc;
                // 期間累計売上額
                dr[PMKHN02054EA.ct_Col_TermSalesMoney] = camWork.CampaignSalesMoneyTaxExc;
                // 当月売上目標1
                dr[PMKHN02054EA.ct_Col_MonthlySalesTarget1] = camWork.MonthlySalesTarget1;
                // 期間累計売上目標1
                dr[PMKHN02054EA.ct_Col_TermSalesTarget1] = camWork.TermSalesTarget1;
                // 当月売上達成率1
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoneyAchivRate1] = this.GetRatio(camWork.AddUpSalesMoneyTaxExc, camWork.MonthlySalesTarget1);
                // 期間累計売上達成率1
                dr[PMKHN02054EA.ct_Col_TermSalesMoneyAchivRate1] = this.GetRatio(camWork.CampaignSalesMoneyTaxExc, camWork.TermSalesTarget1);
                // 当月売上目標2
                dr[PMKHN02054EA.ct_Col_MonthlySalesTarget2] = camWork.MonthlySalesTarget2;
                // 期間累計売上目標2
                dr[PMKHN02054EA.ct_Col_TermSalesTarget2] = camWork.TermSalesTarget2;
                // 当月売上達成率2
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoneyAchivRate2] = this.GetRatio(camWork.AddUpSalesMoneyTaxExc, camWork.MonthlySalesTarget2);
                // 期間累計売上達成率2
                dr[PMKHN02054EA.ct_Col_TermSalesMoneyAchivRate2] = this.GetRatio(camWork.CampaignSalesMoneyTaxExc, camWork.TermSalesTarget2);
                // 当月売上目標3
                dr[PMKHN02054EA.ct_Col_MonthlySalesTarget3] = camWork.MonthlySalesTarget3;
                // 期間累計売上目標3
                dr[PMKHN02054EA.ct_Col_TermSalesTarget3] = camWork.TermSalesTarget3;
                // 当月売上達成率3
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoneyAchivRate3] = this.GetRatio(camWork.AddUpSalesMoneyTaxExc, camWork.MonthlySalesTarget3);
                // 期間累計売上達成率3
                dr[PMKHN02054EA.ct_Col_TermSalesMoneyAchivRate3] = this.GetRatio(camWork.CampaignSalesMoneyTaxExc, camWork.TermSalesTarget3);

                // 当月粗利額
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfit] = camWork.AddUpSalesProfit;
                // 期間累計粗利額
                dr[PMKHN02054EA.ct_Col_TermSalesProfit] = camWork.CampaignSalesProfit;
                // 当月粗利率
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitRate] = this.GetRatio(camWork.AddUpSalesProfit, camWork.AddUpSalesMoneyTaxExc);
                // 期間累計粗利率
                dr[PMKHN02054EA.ct_Col_TermSalesProfitRate] = this.GetRatio(camWork.CampaignSalesProfit, camWork.CampaignSalesMoneyTaxExc);
                // 当月粗利目標1
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetProfit1] = camWork.MonthlySalesTargetProfit1;
                // 期間累計粗利目標1
                dr[PMKHN02054EA.ct_Col_TermSalesTargetProfit1] = camWork.TermSalesTargetProfit1;
                // 当月粗利達成率1
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitAchivRate1] = this.GetRatio(camWork.AddUpSalesProfit, camWork.MonthlySalesTargetProfit1);
                // 期間累計粗利達成率1
                dr[PMKHN02054EA.ct_Col_TermSalesProfitAchivRate1] = this.GetRatio(camWork.CampaignSalesProfit, camWork.TermSalesTargetProfit1);
                // 当月粗利目標2
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetProfit2] = camWork.MonthlySalesTargetProfit2;
                // 期間累計粗利目標2
                dr[PMKHN02054EA.ct_Col_TermSalesTargetProfit2] = camWork.TermSalesTargetProfit2;
                // 当月粗利達成率2
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitAchivRate2] = this.GetRatio(camWork.AddUpSalesProfit, camWork.MonthlySalesTargetProfit2);
                // 期間累計粗利達成率2
                dr[PMKHN02054EA.ct_Col_TermSalesProfitAchivRate2] = this.GetRatio(camWork.CampaignSalesProfit, camWork.TermSalesTargetProfit2);
                // 当月粗利目標3
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetProfit3] = camWork.MonthlySalesTargetProfit3;
                // 期間累計粗利目標3
                dr[PMKHN02054EA.ct_Col_TermSalesTargetProfit3] = camWork.TermSalesTargetProfit3;
                // 当月粗利達成率3
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitAchivRate3] = this.GetRatio(camWork.AddUpSalesProfit, camWork.MonthlySalesTargetProfit3);
                // 期間累計粗利達成率3
                dr[PMKHN02054EA.ct_Col_TermSalesProfitAchivRate3] = this.GetRatio(camWork.CampaignSalesProfit, camWork.TermSalesTargetProfit3);
                
                // TableにAdd
                this._campaignRsltListDt.Rows.Add(dr);
            }

            this._campaignRsltListView = new DataView(this._campaignRsltListDt, "", GetSortOrder(campaignRsltList), DataViewRowState.CurrentRows);
        }

        #region [ソート順の作成]
        /// <summary>
        /// ソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : ソート順を作成する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string GetSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            switch (campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    {
                        strSortOrder = GetGoodsSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                    {
                        strSortOrder = GetCustomerSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別
                    {
                        strSortOrder = GetEmpSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                    {
                        strSortOrder = GetAreaSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachSales: // 販売区分別
                    {
                        strSortOrder = GetSalesSortOrder(campaignRsltList);
                        break;
                    }
            }
            
            return strSortOrder.ToString();
        }

        #region [商品別ソート順の作成]
        /// <summary>
        /// 商品別ソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : 商品別ソート順の作成を行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private StringBuilder GetGoodsSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();
            // 実績計上拠点コード
            strSortOrder.Append(string.Format("{0} ASC", PMKHN02054EA.ct_Col_AddUpSecCode));
            // 品番
            if (campaignRsltList.Detail == 0)
            {
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                if (campaignRsltList.Total == 0)
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    if (campaignRsltList.PrintType != 1)
                    {
                        // 品番＋ﾒｰｶｰ
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // ﾒｰｶｰ＋品番
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
                // BLｺｰﾄﾞ
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    if (campaignRsltList.PrintType != 1)
                    {
                        // 品番＋ﾒｰｶｰ
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // ﾒｰｶｰ＋品番
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
            }
            // BLｺｰﾄﾞ
            else if (campaignRsltList.Detail == 1)
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                }
            }
            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            else
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                }
            }

            return strSortOrder;
        }
        #endregion // 商品別ソート順の作成

        #region [得意先別ソート順の作成]
        /// <summary>
        /// 得意先別ソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : 得意先別ソート順を作成する。</br>
        /// <br>Programmer : jijj</br>
        /// <br>Date       : 2011/05/23</br>
        /// </remarks>
        private StringBuilder GetCustomerSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            if (campaignRsltList.OutputSort == 0) // 得意先
            {
                // 実績計上拠点コード・得意先コード ASC
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_CustomerCode));
                // 余計なソート順
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);
            }
            else if (campaignRsltList.OutputSort == 1) // 拠点
            {
                // 実績計上拠点コード ASC
                strSortOrder.Append(string.Format("{0} ASC", PMKHN02054EA.ct_Col_AddUpSecCode));
                // 余計なソート順
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);
            }
            else if (campaignRsltList.OutputSort == 2) // 得意先-拠点
            {
                // 得意先コード・実績計上拠点コード ASC
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_CustomerCode, PMKHN02054EA.ct_Col_AddUpSecCode));
                // 余計なソート順
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);

            }
            else if (campaignRsltList.OutputSort == 3) // 管理拠点
            {
                // 管理拠点コード・得意先コード ASC
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_ManageSectionCode, PMKHN02054EA.ct_Col_CustomerCode));
                // 余計なソート順
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);
            }

            return strSortOrder;
        }

        /// <summary>
        /// 得意先別subソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <param name="strSortOrder">得意先別subソート順</param>
        /// <remarks>
        /// <br>Note       : 得意先別subソート順を作成する。</br>
        /// <br>Programmer : jijj</br>
        /// <br>Date       : 2011/05/23</br>
        /// </remarks>
        private void GetCustomerSubSortOrder(CampaignRsltList campaignRsltList, ref StringBuilder strSortOrder)
        {
            // 品番
            if (campaignRsltList.Detail == 0)
            {
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                if (campaignRsltList.Total == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ ASC
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));

                    if (campaignRsltList.PrintType != 1)
                    {
                        // 品番＋ﾒｰｶｰ ASC
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // ﾒｰｶｰ＋品番 ACS
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
                // BLｺｰﾄﾞ
                else
                {
                    // BLｺｰﾄﾞ ASC
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));

                    if (campaignRsltList.PrintType != 1)
                    {
                        // 品番＋ﾒｰｶｰ
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // ﾒｰｶｰ＋品番
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
            }
            // BLｺｰﾄﾞ
            else if (campaignRsltList.Detail == 1)
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                }
            }
            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            else
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                }
            }
        }
        #endregion // 得意先別ソート順の作成

        #region [担当者別ソート順の作成]
        /// <summary>
        /// 担当者別ソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : 担当者別ソート順を作成する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private StringBuilder GetEmpSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            if (campaignRsltList.OutputSort == 0) // 0：担当者
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_EmployeeCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        // 印刷タイプが期間の場合
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        // 印刷タイプが期間の場合
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 1) // 1：得意先
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC, {2} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_EmployeeCode, PMKHN02054EA.ct_Col_CustomerCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 2) // 2：担当者－拠点
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_EmployeeCode, PMKHN02054EA.ct_Col_AddUpSecCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 3) // 3：管理拠点
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_ManageSectionCode, PMKHN02054EA.ct_Col_EmployeeCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else
            {
                // なし
            }

            return strSortOrder;
        }
        #endregion // 担当者別ソート順の作成                

        #region [販売区分別ソート順の作成]
        /// <summary>
        /// 販売区分別ソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : 販売区分別ソート順を作成する。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private StringBuilder GetSalesSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_EmployeeCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            return strSortOrder;
        }
        #endregion // 担当者別ソート順の作成

        #region [地区別ソート順の作成]
        /// <summary>
        /// 地区別ソート順の作成
        /// </summary>
        /// <param name="campaignRsltList">UI抽出条件クラス</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : 地区別ソート順を作成する。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/05/26</br>
        /// </remarks>
        private StringBuilder GetAreaSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            if (campaignRsltList.OutputSort == 0) // 0：地区
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_AreaCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 1) // 1：得意先
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC, {2} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_AreaCode, PMKHN02054EA.ct_Col_CustomerCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 2) // 2：地区－拠点
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AreaCode, PMKHN02054EA.ct_Col_AddUpSecCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 3) // 3：管理拠点
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_ManageSectionCode, PMKHN02054EA.ct_Col_AreaCode));
                // 品番
                if (campaignRsltList.Detail == 0)
                {
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BLｺｰﾄﾞ
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // 品番＋ﾒｰｶｰ
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // ﾒｰｶｰ＋品番
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BLｺｰﾄﾞ
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else
            {
                // なし
            }

            return strSortOrder;
        }
        #endregion //地区別ソート順の作成

        #endregion // ソート順の作成

        #endregion

        #region DictionaryのValue用クラス
        /// <summary>
        /// DictionaryのValue用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note		: DictionaryのValue用クラスを作成する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        class CampaignTargetValue
        {
            #region private members
            /// <summary>月間売上目標金額1</summary>
            private Int64 _monthlySalesTarget1;

            /// <summary>売上期間目標金額1</summary>
            private Int64 _termSalesTarget1;

            /// <summary>売上月間目標粗利額1</summary>
            private Int64 _monthlySalesTargetProfit1;

            /// <summary>売上期間目標粗利額1</summary>
            private Int64 _termSalesTargetProfit1;

            /// <summary>売上月間目標数量1</summary>
            private Double _monthlySalesTargetCount1;

            /// <summary>担売上期間目標数量1</summary>
            private Double _termSalesTargetCount1;

            /// <summary>月間売上目標金額2</summary>
            private Int64 _monthlySalesTarget2;

            /// <summary>売上期間目標金額2</summary>
            private Int64 _termSalesTarget2;

            /// <summary>売上月間目標粗利額2</summary>
            private Int64 _monthlySalesTargetProfit2;

            /// <summary>売上期間目標粗利額2</summary>
            private Int64 _termSalesTargetProfit2;

            /// <summary>売上月間目標数量2</summary>
            private Double _monthlySalesTargetCount2;

            /// <summary>売上期間目標数量2</summary>
            private Double _termSalesTargetCount2;

            /// <summary>月間売上目標金額3</summary>
            private Int64 _monthlySalesTarget3;

            /// <summary>売上期間目標金額3</summary>
            private Int64 _termSalesTarget3;

            /// <summary>売上月間目標粗利額3</summary>
            private Int64 _monthlySalesTargetProfit3;

            /// <summary>売上期間目標粗利額3</summary>
            private Int64 _termSalesTargetProfit3;

            /// <summary>売上月間目標数量3</summary>
            private Double _monthlySalesTargetCount3;

            /// <summary>担売上期間目標数量3</summary>
            private Double _termSalesTargetCount3;
            #endregion

            #region Public propaty
            /// public propaty name  :  MonthlySalesTarget1
            /// <summary>月間売上目標金額1プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   月間売上目標金額1プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 MonthlySalesTarget1
            {
                get { return _monthlySalesTarget1; }
                set { _monthlySalesTarget1 = value; }
            }

            /// public propaty name  :  TermSalesTarget1
            /// <summary>売上期間目標金額1プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標金額1プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 TermSalesTarget1
            {
                get { return _termSalesTarget1; }
                set { _termSalesTarget1 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetProfit1
            /// <summary>売上月間目標粗利額1プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上月間目標粗利額1プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 MonthlySalesTargetProfit1
            {
                get { return _monthlySalesTargetProfit1; }
                set { _monthlySalesTargetProfit1 = value; }
            }
            /// public propaty name  :  TermSalesTargetProfit1
            /// <summary>売上期間目標粗利額1プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標粗利プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 TermSalesTargetProfit1
            {
                get { return _termSalesTargetProfit1; }
                set { _termSalesTargetProfit1 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetCount1
            /// <summary>売上月間目標数量1プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上月間目標数量1プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double MonthlySalesTargetCount1
            {
                get { return _monthlySalesTargetCount1; }
                set { _monthlySalesTargetCount1 = value; }
            }
            /// public propaty name  :  TermSalesTargetCount1
            /// <summary>売上期間目標数量1プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標数量1プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TermSalesTargetCount1
            {
                get { return _termSalesTargetCount1; }
                set { _termSalesTargetCount1 = value; }
            }

            /// public propaty name  :  MonthlySalesTarget2
            /// <summary>月間売上目標金額2プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   月間売上目標金額2プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 MonthlySalesTarget2
            {
                get { return _monthlySalesTarget2; }
                set { _monthlySalesTarget2 = value; }
            }
            /// public propaty name  :  TermSalesTarget2
            /// <summary>売上期間目標金額2プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標金額2プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 TermSalesTarget2
            {
                get { return _termSalesTarget2; }
                set { _termSalesTarget2 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetProfit2
            /// <summary>売上月間目標粗利額2プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上月間目標粗利額2プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 MonthlySalesTargetProfit2
            {
                get { return _monthlySalesTargetProfit2; }
                set { _monthlySalesTargetProfit2 = value; }
            }
            /// public propaty name  :  TermSalesTargetProfit2
            /// <summary>売上期間目標粗利額2プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標粗利額2プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 TermSalesTargetProfit2
            {
                get { return _termSalesTargetProfit2; }
                set { _termSalesTargetProfit2 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetCount2
            /// <summary>売上月間目標数量2プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上月間目標数量2プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double MonthlySalesTargetCount2
            {
                get { return _monthlySalesTargetCount2; }
                set { _monthlySalesTargetCount2 = value; }
            }
            /// public propaty name  :  TermSalesTargetCount2
            /// <summary>売上期間目標数量2プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標数量2プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TermSalesTargetCount2
            {
                get { return _termSalesTargetCount2; }
                set { _termSalesTargetCount2 = value; }
            }

            /// public propaty name  :  MonthlySalesTarget1
            /// <summary>月間売上目標金額3プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   月間売上目標金額3プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 MonthlySalesTarget3
            {
                get { return _monthlySalesTarget3; }
                set { _monthlySalesTarget3 = value; }
            }

            /// public propaty name  :  TermSalesTarget3
            /// <summary>売上期間目標金額3プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標金額3プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 TermSalesTarget3
            {
                get { return _termSalesTarget3; }
                set { _termSalesTarget3 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetProfit3
            /// <summary>売上月間目標粗利額3プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上月間目標粗利額3プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 MonthlySalesTargetProfit3
            {
                get { return _monthlySalesTargetProfit3; }
                set { _monthlySalesTargetProfit3 = value; }
            }
            /// public propaty name  :  TermSalesTargetProfit3
            /// <summary>売上期間目標粗利額3プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標粗利プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Int64 TermSalesTargetProfit3
            {
                get { return _termSalesTargetProfit3; }
                set { _termSalesTargetProfit3 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetCount3
            /// <summary>売上月間目標数量3プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上月間目標数量3プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double MonthlySalesTargetCount3
            {
                get { return _monthlySalesTargetCount3; }
                set { _monthlySalesTargetCount3 = value; }
            }
            /// public propaty name  :  TermSalesTargetCount3
            /// <summary>売上期間目標数量3プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   売上期間目標数量3プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TermSalesTargetCount3
            {
                get { return _termSalesTargetCount3; }
                set { _termSalesTargetCount3 = value; }
            }
            #endregion
        }

        /// <summary>
        /// DictionaryのValue用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note		: DictionaryのValue用クラスを作成する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        class DateTerm
        {
            #region private members

            /// <summary>開始</summary>
            private DateTime _dateTimeSt;
            /// <summary>終了</summary>
            private DateTime _dateTimeEd;

            #endregion

            #region Public propaty

            /// public propaty name  :  DateTimeSt
            /// <summary>開始プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   開始プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public DateTime DateTimeSt
            {
                get { return _dateTimeSt; }
                set { _dateTimeSt = value; }
            }
            /// public propaty name  :  DateTimeEd
            /// <summary>終了プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   終了プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public DateTime DateTimeEd
            {
                get { return _dateTimeEd; }
                set { _dateTimeEd = value; }
            }
            #endregion
        }
        #endregion        
    }
}
