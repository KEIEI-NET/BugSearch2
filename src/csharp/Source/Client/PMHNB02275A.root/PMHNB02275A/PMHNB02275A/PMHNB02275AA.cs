//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売掛残高一覧表(総括)
// プログラム概要   : 売掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/03/10     修正内容：Mantis.15091 出力金額区分の抽出単位が得意先になっている件の修正
// ---------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11800255-00 作成担当 : 陳艶丹
// 修 正 日  2022/10/13  修正内容 : インボイス対応（税率別合計金額不具合修正）
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
    /// 売掛残高一覧表(総括)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高一覧表(総括)で使用するデータを取得する。</br>
    /// <br></br>
    /// <br>UpdateNote :   11570208-00 軽減税率対応</br>
    /// <br>Programmer :   3H 劉星光</br>
    /// <br>Date	   :   2020/04/10</br>
    /// </remarks>
	public class SumBillBalanceAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表(総括)アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)アクセスクラスの初期化を行う。</br>
        /// <br></br>
        /// </remarks>
		public SumBillBalanceAcs()
		{
            this._iSumBillBalanceTableDB = (ISumBillBalanceTableDB)MediationSumBillBalanceTableDB.GetBillBalanceTableDB();
		}

		/// <summary>
        /// 売掛残高一覧表(総括)アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)アクセスクラスの初期化を行う。</br>
        /// <br></br>
        /// </remarks>
		static SumBillBalanceAcs()
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
        ISumBillBalanceTableDB _iSumBillBalanceTableDB;

        private DataSet _sumBillBalanceDs;				    // 売掛残高一覧表(総括)データセット

        // 拠点毎の月次締未更新キャッシュ
        private Dictionary<string, bool> _monAddUpNonProcDic;
                
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
        /// 売掛残高一覧表(総括)データセット(読み取り専用)
		/// </summary>
		public DataSet SumBillBalanceDs
		{
			get{ return this._sumBillBalanceDs; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
        #region ◎ 売掛残高一覧表(総括)データ取得
        /// <summary>
        /// 売掛残高一覧表(総括)データ取得
		/// </summary>
        /// <param name="sumExtrInfo_BillBalance">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する売掛残高一覧表(総括)データを取得する。</br>
        /// <br></br>
        /// </remarks>
        public int SearchSumBillBalance(SumExtrInfo_BillBalance sumExtrInfo_BillBalance, out string errMsg)
		{
            return this.SearchSumBillBalanceProc(sumExtrInfo_BillBalance, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
        #region ◎ 売掛残高一覧表(総括)データ取得
        /// <summary>
        /// 売掛残高一覧表(総括)データ取得
		/// </summary>
        /// <param name="sumExtrInfo_BillBalance"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
        /// <br></br>
        /// </remarks>
        private int SearchSumBillBalanceProc(SumExtrInfo_BillBalance sumExtrInfo_BillBalance, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMHNB02274EA.CreateDataTableSumBillBalance(ref this._sumBillBalanceDs);
                SumExtrInfo_BillBalanceWork sumExtrInfo_BillBalanceWork = new SumExtrInfo_BillBalanceWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevSumBillBalanceCndtn(sumExtrInfo_BillBalance, out sumExtrInfo_BillBalanceWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retList = null;
                status = this._iSumBillBalanceTableDB.Search(out retList, sumExtrInfo_BillBalanceWork, 0, ConstantManagement.LogicalMode.GetData0);
                
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // キャッシュの初期化
                        _monAddUpNonProcDic = new Dictionary<string, bool>();
                        
                        // データ展開処理
                        DevSumBillBalanceData(sumExtrInfo_BillBalance, this._sumBillBalanceDs.Tables[PMHNB02274EA.Col_Tbl_SumBillBalance], (ArrayList)retList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._sumBillBalanceDs.Tables[PMHNB02274EA.Col_Tbl_SumBillBalance].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
                        errMsg = "売掛残高一覧表(総括)データの取得に失敗しました。";
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
        /// <param name="sumExtrInfo_BillBalance">UI抽出条件クラス</param>
        /// <param name="sumExtrInfo_BillBalanceWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        private int DevSumBillBalanceCndtn(SumExtrInfo_BillBalance sumExtrInfo_BillBalance, out SumExtrInfo_BillBalanceWork sumExtrInfo_BillBalanceWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            sumExtrInfo_BillBalanceWork = new SumExtrInfo_BillBalanceWork();

			try
			{
				sumExtrInfo_BillBalanceWork.EnterpriseCode = sumExtrInfo_BillBalance.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (sumExtrInfo_BillBalance.CollectAddupSecCodeList.Length != 0)
				{
					if ( sumExtrInfo_BillBalance.IsSelectAllSection )
					{
						// 全社の時
                        sumExtrInfo_BillBalanceWork.SectionCodes = null;
					}
					else
					{
                        sumExtrInfo_BillBalanceWork.SectionCodes = sumExtrInfo_BillBalance.CollectAddupSecCodeList;
					}
				}
				else
				{
                    sumExtrInfo_BillBalanceWork.SectionCodes = null;
				}

                sumExtrInfo_BillBalanceWork.AddUpDate = sumExtrInfo_BillBalance.AddUpDate;                  // 計上年月日
                sumExtrInfo_BillBalanceWork.AddUpYearMonth = sumExtrInfo_BillBalance.AddUpYearMonth;        // 対象年月
                sumExtrInfo_BillBalanceWork.SortOrderDiv = (int)sumExtrInfo_BillBalance.SortOrderDiv;       // 出力順
                sumExtrInfo_BillBalanceWork.St_ClaimCode = sumExtrInfo_BillBalance.St_ClaimCode;	        // 開始請求先コード
                if (sumExtrInfo_BillBalance.Ed_ClaimCode == 0)
                {
                    // 未入力の場合は、最大値をセット
                    sumExtrInfo_BillBalanceWork.Ed_ClaimCode = 99999999;	                                // 終了請求先コード
                }
                else
                {
                    sumExtrInfo_BillBalanceWork.Ed_ClaimCode = sumExtrInfo_BillBalance.Ed_ClaimCode;	    // 終了請求先コード
                }
                sumExtrInfo_BillBalanceWork.St_SalesAreaCode = sumExtrInfo_BillBalance.St_SalesAreaCode;	// 開始販売エリアコード
                if (sumExtrInfo_BillBalance.Ed_SalesAreaCode == 0)
                {
                    // 未入力の場合は、最大値をセット
                    sumExtrInfo_BillBalanceWork.Ed_SalesAreaCode = 9999;                                    // 終了販売エリアコード
                }
                else
                {
                    sumExtrInfo_BillBalanceWork.Ed_SalesAreaCode = sumExtrInfo_BillBalance.Ed_SalesAreaCode;// 終了販売エリアコード
                }
                sumExtrInfo_BillBalanceWork.EmployeeKindDiv = (int)sumExtrInfo_BillBalance.EmployeeKindDiv; // 担当者区分
                sumExtrInfo_BillBalanceWork.St_EmployeeCode = sumExtrInfo_BillBalance.St_EmployeeCode;      // 開始担当者コード
                sumExtrInfo_BillBalanceWork.Ed_EmployeeCode = sumExtrInfo_BillBalance.Ed_EmployeeCode;	    // 終了担当者コード
                sumExtrInfo_BillBalanceWork.DepoDtlDiv = sumExtrInfo_BillBalance.DepoDtlDiv;

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 税別内訳印字区分
                sumExtrInfo_BillBalanceWork.TaxPrintDiv = sumExtrInfo_BillBalance.TaxPrintDiv;
                // 税率1
                sumExtrInfo_BillBalanceWork.TaxRate1 = sumExtrInfo_BillBalance.TaxRate1;
                // 税率2
                sumExtrInfo_BillBalanceWork.TaxRate2 = sumExtrInfo_BillBalance.TaxRate2;
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

        #region ◎ 売掛残高一覧表(総括)データ展開処理
        /// <summary>
        /// 売掛残高一覧表(総括)データ展開処理
		/// </summary>
        /// <param name="sumExtrInfo_BillBalance">UI抽出条件クラス</param>
        /// <param name="sumBillBalanceDt">展開対象DataTable</param>
        /// <param name="sumRsltInfo_BillBalanceWorkList">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)データを展開する。</br>
        /// <br></br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        private void DevSumBillBalanceData(SumExtrInfo_BillBalance sumExtrInfo_BillBalance, DataTable sumBillBalanceDt, ArrayList sumRsltInfo_BillBalanceWorkList)
		{
			DataRow dr;
            // 2010/03/10 Add >>>
            ArrayList addUpSecCodeList = new ArrayList();
            ArrayList claimCodeList = new ArrayList();
            // 2010/03/10 Add <<<
            foreach (SumRsltInfo_BillBalanceWork sumRsltInfo_BillBalanceWork in sumRsltInfo_BillBalanceWorkList)
			{
                // 2010/03/10 Del >>>
                //// 出力金額区分チェック
                //if (!CheckOutputMoneyDiv(sumExtrInfo_BillBalance, sumRsltInfo_BillBalanceWork))
                //{
                //    // 印刷対象データでは無い
                //    continue;
                //}
                // 2010/03/10 Del <<<

                // 総括請求先の拠点と得意先をキーに設定
                sumBillBalanceDt.PrimaryKey = new DataColumn[] { sumBillBalanceDt.Columns[PMHNB02274EA.Col_AddUpSecCode],
                                                                 sumBillBalanceDt.Columns[PMHNB02274EA.Col_ClaimCode] };
                object[] keys = new object[]{sumRsltInfo_BillBalanceWork.AddUpSecCode, sumRsltInfo_BillBalanceWork.ClaimCode};
                dr = sumBillBalanceDt.Rows.Find(keys);
                if (dr != null)
                {
                    // キーの総括請求先が存在している場合は、金額を更新する
                    // 前回売掛金額
                    dr[PMHNB02274EA.Col_LastTimeAccRec] = (long)dr[PMHNB02274EA.Col_LastTimeAccRec] + sumRsltInfo_BillBalanceWork.LastTimeAccRec;
                    // 今回入金金額
                    dr[PMHNB02274EA.Col_ThisTimeDmdNrml] = (long)dr[PMHNB02274EA.Col_ThisTimeDmdNrml] + sumRsltInfo_BillBalanceWork.ThisTimeDmdNrml;
                    // 今回繰越残高
                    dr[PMHNB02274EA.Col_ThisTimeTtlBlcAcc] = (long)dr[PMHNB02274EA.Col_ThisTimeTtlBlcAcc] + sumRsltInfo_BillBalanceWork.ThisTimeTtlBlcAcc;
                    // 相殺後今回売上金額
                    dr[PMHNB02274EA.Col_OfsThisTimeSales] = (long)dr[PMHNB02274EA.Col_OfsThisTimeSales] + sumRsltInfo_BillBalanceWork.OfsThisTimeSales;
                    // 返品値引
                    long thisRgdsDisPricTtl = (long)dr[PMHNB02274EA.Col_ThisRgdsDisPric] - sumRsltInfo_BillBalanceWork.ThisRgdsDisPric;
                    dr[PMHNB02274EA.Col_ThisRgdsDisPric] = thisRgdsDisPricTtl;
                    // 相殺後今回売上消費税
                    dr[PMHNB02274EA.Col_OfsThisSalesTax] = (long)dr[PMHNB02274EA.Col_OfsThisSalesTax] + sumRsltInfo_BillBalanceWork.OfsThisSalesTax;
                    // 今回売上金額
                    dr[PMHNB02274EA.Col_ThisTimeSales] = (long)dr[PMHNB02274EA.Col_ThisTimeSales] + sumRsltInfo_BillBalanceWork.ThisTimeSales;
                    // 計算後当月売掛金額
                    dr[PMHNB02274EA.Col_AfCalTMonthAccRec] = (long)dr[PMHNB02274EA.Col_AfCalTMonthAccRec] + sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec;
                    // 伝票枚数
                    dr[PMHNB02274EA.Col_SalesSlipCount] = (int)dr[PMHNB02274EA.Col_SalesSlipCount] + sumRsltInfo_BillBalanceWork.SalesSlipCount;
                   // 手数料
                    dr[PMHNB02274EA.Col_ThisTimeFeeDmdNrml] = (long)dr[PMHNB02274EA.Col_ThisTimeFeeDmdNrml] + sumRsltInfo_BillBalanceWork.ThisTimeFeeDmdNrml;
                    // 値引
                    dr[PMHNB02274EA.Col_ThisTimeDisDmdNrml] = (long)dr[PMHNB02274EA.Col_ThisTimeDisDmdNrml] + sumRsltInfo_BillBalanceWork.ThisTimeDisDmdNrml;
                    // 現金
                    dr[PMHNB02274EA.Col_CashDeposit] = (long)dr[PMHNB02274EA.Col_CashDeposit] + sumRsltInfo_BillBalanceWork.CashDeposit;
                    // 振込
                    dr[PMHNB02274EA.Col_TrfrDeposit] = (long)dr[PMHNB02274EA.Col_TrfrDeposit] + sumRsltInfo_BillBalanceWork.TrfrDeposit;
                    // 小切手
                    dr[PMHNB02274EA.Col_CheckDeposit] = (long)dr[PMHNB02274EA.Col_CheckDeposit] + sumRsltInfo_BillBalanceWork.CheckDeposit;
                    // 手形
                    dr[PMHNB02274EA.Col_DraftDeposit] = (long)dr[PMHNB02274EA.Col_DraftDeposit] + sumRsltInfo_BillBalanceWork.DraftDeposit;
                    // 相殺
                    dr[PMHNB02274EA.Col_OffsetDeposit] = (long)dr[PMHNB02274EA.Col_OffsetDeposit] + sumRsltInfo_BillBalanceWork.OffsetDeposit;
                    // 口座振替
                    dr[PMHNB02274EA.Col_FundTransferDeposit] = (long)dr[PMHNB02274EA.Col_FundTransferDeposit] + sumRsltInfo_BillBalanceWork.FundTransferDeposit;
                    // その他
                    dr[PMHNB02274EA.Col_OthsDeposit] = (long)dr[PMHNB02274EA.Col_OthsDeposit] + sumRsltInfo_BillBalanceWork.OthsDeposit;
                    // 純売上額(相殺後今回売上金額)
                    long pureSalesTtl = (long)dr[PMHNB02274EA.ct_Col_PureSales] + sumRsltInfo_BillBalanceWork.OfsThisTimeSales;
                    dr[PMHNB02274EA.ct_Col_PureSales] = pureSalesTtl;
                    // 当月合計
                    dr[PMHNB02274EA.Col_SalesPricTax] = pureSalesTtl + (long)dr[PMHNB02274EA.Col_OfsThisSalesTax];

                    // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                    // 売上額(計税率1)
                    dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxRate1] = (long)dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxRate1] + sumRsltInfo_BillBalanceWork.TotalThisTimeSalesTaxRate1;
                    // 売上額(計税率2)
                    dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxRate2] = (long)dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxRate2] + sumRsltInfo_BillBalanceWork.TotalThisTimeSalesTaxRate2;
                    // 売上額(計その他)
                    dr[PMHNB02274EA.Col_TotalThisTimeSalesOther] = (long)dr[PMHNB02274EA.Col_TotalThisTimeSalesOther] + sumRsltInfo_BillBalanceWork.TotalThisTimeSalesOther;
                    // 返品値引(計税率1)
                    dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxRate1] = (long)dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxRate1] + sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricTaxRate1;
                    // 返品値引(計税率2)
                    dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxRate2] = (long)dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxRate2] + sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricTaxRate2;
                    // 返品値引(計その他)
                    dr[PMHNB02274EA.Col_TotalThisRgdsDisPricOther] = (long)dr[PMHNB02274EA.Col_TotalThisRgdsDisPricOther] + sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricOther;
                    // 純売上額(計税率1)
                    dr[PMHNB02274EA.Col_TotalPureSalesTaxRate1] = (long)dr[PMHNB02274EA.Col_TotalPureSalesTaxRate1] + sumRsltInfo_BillBalanceWork.TotalPureSalesTaxRate1;
                    // 純売上額(計税率2)
                    dr[PMHNB02274EA.Col_TotalPureSalesTaxRate2] = (long)dr[PMHNB02274EA.Col_TotalPureSalesTaxRate2] + sumRsltInfo_BillBalanceWork.TotalPureSalesTaxRate2;
                    // 純売上額(計その他)
                    dr[PMHNB02274EA.Col_TotalPureSalesOther] = (long)dr[PMHNB02274EA.Col_TotalPureSalesOther] + sumRsltInfo_BillBalanceWork.TotalPureSalesOther;
                    // 消費税(計税率1)
                    dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxRate1] = (long)dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxRate1] + sumRsltInfo_BillBalanceWork.TotalSalesPricTaxTaxRate1;
                    // 消費税(計税率2)
                    dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxRate2] = (long)dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxRate2] + sumRsltInfo_BillBalanceWork.TotalSalesPricTaxTaxRate2;
                    // 消費税(計その他)
                    dr[PMHNB02274EA.Col_TotalSalesPricTaxOther] = (long)dr[PMHNB02274EA.Col_TotalSalesPricTaxOther] + sumRsltInfo_BillBalanceWork.TotalSalesPricTaxOther;
                    // 当月合計(計税率1)
                    dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxRate1] = (long)dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxRate1] + sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecTaxRate1;
                    // 当月合計(計税率2)
                    dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxRate2] = (long)dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxRate2] + sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecTaxRate2;
                    // 当月合計(計その他)
                    dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecOther] = (long)dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecOther] + sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecOther;
                    // 枚数(計税率1)
                    dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxRate1] = (int)dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxRate1] + sumRsltInfo_BillBalanceWork.TotalSalesSlipCountTaxRate1;
                    // 枚数(計税率2)
                    dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxRate2] = (int)dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxRate2] + sumRsltInfo_BillBalanceWork.TotalSalesSlipCountTaxRate2;
                    // 枚数(計その他)
                    dr[PMHNB02274EA.Col_TotalSalesSlipCountOther] = (int)dr[PMHNB02274EA.Col_TotalSalesSlipCountOther] + sumRsltInfo_BillBalanceWork.TotalSalesSlipCountOther;
                    // 税率1タイトル
                    dr[PMHNB02274EA.Col_TitleTaxRate1] = sumRsltInfo_BillBalanceWork.TitleTaxRate1;
                    // 税率2タイトル
                    dr[PMHNB02274EA.Col_TitleTaxRate2] = sumRsltInfo_BillBalanceWork.TitleTaxRate2;
                    // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
                    continue;
                }

                // 2010/03/10 Add >>>
                addUpSecCodeList.Add(keys[0]);
                claimCodeList.Add(keys[1]);
                // 2010/03/10 Add <<<
                
                // 新規行を作成
                dr = sumBillBalanceDt.NewRow();

                // 計上拠点コード
                dr[PMHNB02274EA.Col_AddUpSecCode] = sumRsltInfo_BillBalanceWork.AddUpSecCode;
                // 計上拠点名称
                dr[PMHNB02274EA.Col_SectionGuideSnm] = sumRsltInfo_BillBalanceWork.SectionGuideSnm.TrimEnd();
                // 請求先コード
                dr[PMHNB02274EA.Col_ClaimCode] = sumRsltInfo_BillBalanceWork.ClaimCode;
                // 請求先略称
                dr[PMHNB02274EA.Col_ClaimSnm] = sumRsltInfo_BillBalanceWork.ClaimSnm;
                // 販売エリアコード
                dr[PMHNB02274EA.Col_SalesAreaCode] = sumRsltInfo_BillBalanceWork.SalesAreaCode;
                // 販売エリア名称
                dr[PMHNB02274EA.Col_SalesAreaName] = sumRsltInfo_BillBalanceWork.SalesAreaName;

                // 前回売掛金額
                dr[PMHNB02274EA.Col_LastTimeAccRec] = sumRsltInfo_BillBalanceWork.LastTimeAccRec;
                // 今回入金金額
                dr[PMHNB02274EA.Col_ThisTimeDmdNrml] = sumRsltInfo_BillBalanceWork.ThisTimeDmdNrml;
                // 今回繰越残高
                dr[PMHNB02274EA.Col_ThisTimeTtlBlcAcc] = sumRsltInfo_BillBalanceWork.ThisTimeTtlBlcAcc;
                // 相殺後今回売上金額
                dr[PMHNB02274EA.Col_OfsThisTimeSales] = sumRsltInfo_BillBalanceWork.OfsThisTimeSales;
                // 返品値引
                long thisRgdsDisPric = sumRsltInfo_BillBalanceWork.ThisRgdsDisPric;
                dr[PMHNB02274EA.Col_ThisRgdsDisPric] = -thisRgdsDisPric;
                // 相殺後今回売上消費税
                dr[PMHNB02274EA.Col_OfsThisSalesTax] = sumRsltInfo_BillBalanceWork.OfsThisSalesTax;
                // 今回売上金額
                dr[PMHNB02274EA.Col_ThisTimeSales] = sumRsltInfo_BillBalanceWork.ThisTimeSales;
                // 計算後当月売掛金額
                dr[PMHNB02274EA.Col_AfCalTMonthAccRec] = sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec;
                // 伝票枚数
                dr[PMHNB02274EA.Col_SalesSlipCount] = sumRsltInfo_BillBalanceWork.SalesSlipCount;
                // 担当者コード
                dr[PMHNB02274EA.Col_AgentCd] = sumRsltInfo_BillBalanceWork.AgentCd;
                // 担当者名
                dr[PMHNB02274EA.Col_Name] = sumRsltInfo_BillBalanceWork.Name;
                // 手数料
                dr[PMHNB02274EA.Col_ThisTimeFeeDmdNrml] = sumRsltInfo_BillBalanceWork.ThisTimeFeeDmdNrml;
                // 値引
                dr[PMHNB02274EA.Col_ThisTimeDisDmdNrml] = sumRsltInfo_BillBalanceWork.ThisTimeDisDmdNrml;
                // 現金
                dr[PMHNB02274EA.Col_CashDeposit] = sumRsltInfo_BillBalanceWork.CashDeposit;
                // 振込
                dr[PMHNB02274EA.Col_TrfrDeposit] = sumRsltInfo_BillBalanceWork.TrfrDeposit;
                // 小切手
                dr[PMHNB02274EA.Col_CheckDeposit] = sumRsltInfo_BillBalanceWork.CheckDeposit;
                // 手形
                dr[PMHNB02274EA.Col_DraftDeposit] = sumRsltInfo_BillBalanceWork.DraftDeposit;
                // 相殺
                dr[PMHNB02274EA.Col_OffsetDeposit] = sumRsltInfo_BillBalanceWork.OffsetDeposit;
                // 口座振替
                dr[PMHNB02274EA.Col_FundTransferDeposit] = sumRsltInfo_BillBalanceWork.FundTransferDeposit;
                // その他
                dr[PMHNB02274EA.Col_OthsDeposit] = sumRsltInfo_BillBalanceWork.OthsDeposit;

                // 純売上額(相殺後今回売上金額)
                long pureSales = sumRsltInfo_BillBalanceWork.OfsThisTimeSales;
                dr[PMHNB02274EA.ct_Col_PureSales] = pureSales;
                // 当月合計
                dr[PMHNB02274EA.Col_SalesPricTax] = pureSales + sumRsltInfo_BillBalanceWork.OfsThisSalesTax;
                // 月次締未更新チェック
                dr[PMHNB02274EA.Col_MonAddUpNonProc] = CheckMonAddUpNonProc(sumExtrInfo_BillBalance, sumRsltInfo_BillBalanceWork);

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 売上額(計税率1)
                dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxRate1] = sumRsltInfo_BillBalanceWork.TotalThisTimeSalesTaxRate1;
                // 売上額(計税率2)
                dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxRate2] = sumRsltInfo_BillBalanceWork.TotalThisTimeSalesTaxRate2;
                // 売上額(計その他)
                dr[PMHNB02274EA.Col_TotalThisTimeSalesOther] = sumRsltInfo_BillBalanceWork.TotalThisTimeSalesOther;
                // 返品値引(計税率1)
                dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxRate1] = sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricTaxRate1;
                // 返品値引(計税率2)
                dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxRate2] = sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricTaxRate2;
                // 返品値引(計その他)
                dr[PMHNB02274EA.Col_TotalThisRgdsDisPricOther] = sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricOther;
                // 純売上額(計税率1)
                dr[PMHNB02274EA.Col_TotalPureSalesTaxRate1] = sumRsltInfo_BillBalanceWork.TotalPureSalesTaxRate1;
                // 純売上額(計税率2)
                dr[PMHNB02274EA.Col_TotalPureSalesTaxRate2] = sumRsltInfo_BillBalanceWork.TotalPureSalesTaxRate2;
                // 純売上額(計その他)
                dr[PMHNB02274EA.Col_TotalPureSalesOther] = sumRsltInfo_BillBalanceWork.TotalPureSalesOther;
                // 消費税(計税率1)
                dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxRate1] = sumRsltInfo_BillBalanceWork.TotalSalesPricTaxTaxRate1;
                // 消費税(計税率2)
                dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxRate2] = sumRsltInfo_BillBalanceWork.TotalSalesPricTaxTaxRate2;
                // 消費税(計その他)
                dr[PMHNB02274EA.Col_TotalSalesPricTaxOther] = sumRsltInfo_BillBalanceWork.TotalSalesPricTaxOther;
                // 当月合計(計税率1)
                dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxRate1] = sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecTaxRate1;
                // 当月合計(計税率2)
                dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxRate2] = sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecTaxRate2;
                // 当月合計(計その他)
                dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecOther] = sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecOther;
                // 枚数(計税率1)
                dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxRate1] = sumRsltInfo_BillBalanceWork.TotalSalesSlipCountTaxRate1;
                // 枚数(計税率2)
                dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxRate2] = sumRsltInfo_BillBalanceWork.TotalSalesSlipCountTaxRate2;
                // 枚数(計その他)
                dr[PMHNB02274EA.Col_TotalSalesSlipCountOther] = sumRsltInfo_BillBalanceWork.TotalSalesSlipCountOther;
                // 税率1タイトル
                dr[PMHNB02274EA.Col_TitleTaxRate1] = sumRsltInfo_BillBalanceWork.TitleTaxRate1;
                // 税率2タイトル
                dr[PMHNB02274EA.Col_TitleTaxRate2] = sumRsltInfo_BillBalanceWork.TitleTaxRate2;
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

                // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                // 売上額(計非課税)
                dr[PMHNB02274EA.Col_TotalThisTimeSalesTaxFree] = sumRsltInfo_BillBalanceWork.TotalThisTimeSalesTaxFree;
                // 返品値引(計非課税)
                dr[PMHNB02274EA.Col_TotalThisRgdsDisPricTaxFree] = sumRsltInfo_BillBalanceWork.TotalThisRgdsDisPricTaxFree;
                // 純売上額((計非課税)
                dr[PMHNB02274EA.Col_TotalPureSalesTaxFree] = sumRsltInfo_BillBalanceWork.TotalPureSalesTaxFree;
                // 消費税(計非課税)
                dr[PMHNB02274EA.Col_TotalSalesPricTaxTaxFree] = sumRsltInfo_BillBalanceWork.TotalSalesPricTaxTaxFree;
                // 当月合計(計非課税)
                dr[PMHNB02274EA.Col_TotalAfCalTMonthAccRecTaxFree] = sumRsltInfo_BillBalanceWork.TotalAfCalTMonthAccRecTaxFree;
                // 枚数(計非課税)
                dr[PMHNB02274EA.Col_TotalSalesSlipCountTaxFree] = sumRsltInfo_BillBalanceWork.TotalSalesSlipCountTaxFree;
                // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

                // TableにAdd
				sumBillBalanceDt.Rows.Add( dr );
			}
            // 2010/03/10 Add >>>
            for (int i = 0; i < addUpSecCodeList.Count; i++)
            {
                object[] keys = new object[] { addUpSecCodeList[i], claimCodeList[i] };
                dr = sumBillBalanceDt.Rows.Find(keys);
                SumRsltInfo_BillBalanceWork sumRsltInfo_BillBalanceWork = new SumRsltInfo_BillBalanceWork();
                sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec = (long)dr[PMHNB02274EA.Col_AfCalTMonthAccRec];
                // 出力金額区分チェック
                if (!CheckOutputMoneyDiv(sumExtrInfo_BillBalance, sumRsltInfo_BillBalanceWork))
                {
                    // 印刷対象データでは無い
                    sumBillBalanceDt.Rows.Remove(dr);
                }
            }
            // 2010/03/10 Add <<<
        }
		#endregion

        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="sumExtrInfo_BillBalance">UI抽出条件クラス</param>
        /// <param name="sumRsltInfo_BillBalanceWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力金額区分で今回入金額をチェックする。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(SumExtrInfo_BillBalance sumExtrInfo_BillBalance, SumRsltInfo_BillBalanceWork sumRsltInfo_BillBalanceWork)
        {
            bool bRet = false;

            // 出力金額区分で計算後当月売掛金額のチェック
            switch ((SumExtrInfo_BillBalance.OutMoneyDivState)sumExtrInfo_BillBalance.OutMoneyDiv)
            {
                case SumExtrInfo_BillBalance.OutMoneyDivState.All: // 全て出力 
                    {
                        bRet = true;
                        break;
                    }
                case SumExtrInfo_BillBalance.OutMoneyDivState.ZeroPlus: // ０とプラス金額を出力
                    {
                        if (sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec >= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumExtrInfo_BillBalance.OutMoneyDivState.Plus: // プラス金額のみ出力
                    {
                        if (sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec > 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumExtrInfo_BillBalance.OutMoneyDivState.Zero: // ０のみ出力
                    {
                        if (sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec == 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumExtrInfo_BillBalance.OutMoneyDivState.PlusMinus: // プラス金額とマイナス金額を出力
                    {
                        if (sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec != 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumExtrInfo_BillBalance.OutMoneyDivState.ZeroMinus: // ０とマイナス金額を出力
                    {
                        if (sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec <= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumExtrInfo_BillBalance.OutMoneyDivState.Minus: // マイナス金額のみ出力
                    {
                        if (sumRsltInfo_BillBalanceWork.AfCalTMonthAccRec < 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                default:
                    break;
            }
            
            return bRet;
        }

        /// <summary>
        /// 月次締未更新チェック
        /// </summary>
        /// <param name="sumExtrInfo_BillBalance">UI抽出条件クラス</param>
        /// <param name="sumRsltInfo_BillBalanceWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 拠点毎の月次締未更新チェックを行う。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckMonAddUpNonProc(SumExtrInfo_BillBalance sumExtrInfo_BillBalance, SumRsltInfo_BillBalanceWork sumRsltInfo_BillBalanceWork)
        {
            bool retb = false;
            string key = sumRsltInfo_BillBalanceWork.AddUpSecCode.TrimEnd();

            if (_monAddUpNonProcDic.ContainsKey(key))
            {
                // 該当拠点の月次締未更新チェック済
                retb = _monAddUpNonProcDic[key];
            }
            else
            {
                // 該当拠点の月次締未更新チェック
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(key, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

                if (prevTotalMonth == DateTime.MinValue)
                {
                    // 月次締未更新
                    _monAddUpNonProcDic.Add(key, true);
                    retb = true;

                }
                else
                {
                    // 月次締更新
                    if (prevTotalMonth < sumExtrInfo_BillBalance.AddUpYearMonth)
                    {
                        // 処理月が前回締更新月より未来
                        _monAddUpNonProcDic.Add(key, true);
                        retb = true;
                    }
                    else
                    {
                        // 処理月が前回締更新月以前
                        _monAddUpNonProcDic.Add(key, false);
                        retb = false;
                    }
                }
            }
            return retb;
        }

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
        /// <br></br>
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
		#endregion
		#endregion ◆ 帳票設定データ取得
		#endregion ■ Private Method
	}
}
