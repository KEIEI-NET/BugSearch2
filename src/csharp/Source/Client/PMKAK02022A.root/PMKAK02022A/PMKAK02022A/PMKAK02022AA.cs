//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表(総括)アクセスクラス
// プログラム概要   : 買掛残高一覧表(総括)で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成 仕入総括機能対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11870141-00 作成担当 : 3H 仰亮亮
// 修 正 日  2022/10/20  修正内容 : インボイス対応（税率別合計金額不具合修正）
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
    /// 買掛残高一覧表(総括)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高一覧表(総括)で使用するデータを取得する。</br>
    /// <br>Programmer : FSI冨樫 紗由里</br>
    /// <br>Date       : 2012/09/14</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/10/20</br>
    /// </remarks>
	public class SumAccPaymentListAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 買掛残高一覧表(総括)アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 買掛残高一覧表(総括)アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		public SumAccPaymentListAcs()
		{
            this._iSumAccPaymentListWorkDB = (ISumAccPaymentListWorkDB)MediationSumAccPaymentListWorkDB.GetSumAccPaymentListWorkDB();
		}

		/// <summary>
		/// 買掛残高一覧表(総括)アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 買掛残高一覧表(総括)アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		static SumAccPaymentListAcs()
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
        private ISumAccPaymentListWorkDB _iSumAccPaymentListWorkDB;

		private DataSet _AccPaymentListDs;				    // 仕入先買掛データセット

        private Dictionary<string, bool> _monAddUpNonProcDic;

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
        /// 仕入先買掛金額データセット(読み取り専用)
		/// </summary>
		public DataSet CustAccRecDs
		{
			get{ return this._AccPaymentListDs; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
        #region ◎ 仕入先買掛金額データ取得
        /// <summary>
        /// 仕入先買掛金額データ取得
		/// </summary>
        /// <param name="sumAccPaymentListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する仕入先買掛金額データを取得する。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
        public int SearchCustAccRecMain(SumAccPaymentListCndtn sumAccPaymentListCndtn, out string errMsg)
		{
            return this.SearchProc(sumAccPaymentListCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
        #region ◎ 仕入先買掛金額データ取得
        /// <summary>
        /// 仕入先買掛金額データ取得
		/// </summary>
        /// <param name="sumAccPaymentListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
        private int SearchProc(SumAccPaymentListCndtn sumAccPaymentListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMKAK02025EA.CreateDataTable(ref this._AccPaymentListDs);
                
                SumAccPaymentListCndtnWork sumAccPaymentListCndtnWork = new SumAccPaymentListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevSumAccPaymentListCndtn(sumAccPaymentListCndtn, out sumAccPaymentListCndtnWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retCustAccRecMainList = null;

                status = this._iSumAccPaymentListWorkDB.Search( out retCustAccRecMainList, sumAccPaymentListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0 );
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        _monAddUpNonProcDic = new Dictionary<string, bool>();
                        
                        // データ展開処理
                        DevListData(sumAccPaymentListCndtn, this._AccPaymentListDs.Tables[PMKAK02025EA.ct_Tbl_AccPaymentList], (ArrayList)retCustAccRecMainList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._AccPaymentListDs.Tables[PMKAK02025EA.ct_Tbl_AccPaymentList].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
                        errMsg = "仕入先買掛金額データの取得に失敗しました。";
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
		/// <param name="sumAccPaymentListCndtn">UI抽出条件クラス</param>
		/// <param name="sumAccPaymentListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        private int DevSumAccPaymentListCndtn(SumAccPaymentListCndtn sumAccPaymentListCndtn, out SumAccPaymentListCndtnWork sumAccPaymentListCndtnWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            sumAccPaymentListCndtnWork = new SumAccPaymentListCndtnWork();

			try
			{
                // 抽出条件プロパティの変更
                sumAccPaymentListCndtnWork.EnterpriseCode = sumAccPaymentListCndtn.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (sumAccPaymentListCndtn.SectionCodes.Length != 0)
				{
					if ( sumAccPaymentListCndtn.IsSelectAllSection )
					{
						// 全社の時
                        sumAccPaymentListCndtnWork.SectionCodes = null;
					}
					else
					{
                        sumAccPaymentListCndtnWork.SectionCodes = sumAccPaymentListCndtn.SectionCodes;
					}
				}
				else
				{
                    sumAccPaymentListCndtnWork.SectionCodes = null;
				}
                                          
                sumAccPaymentListCndtnWork.EnterpriseCode = sumAccPaymentListCndtn.EnterpriseCode; // 企業コード
                sumAccPaymentListCndtnWork.SectionCodes = sumAccPaymentListCndtn.SectionCodes; // 拠点コード（複数指定）
                sumAccPaymentListCndtnWork.AddUpYearMonth = sumAccPaymentListCndtn.AddUpYearMonth; // 計上年月
                sumAccPaymentListCndtnWork.St_PayeeCode = sumAccPaymentListCndtn.St_PayeeCode; // 開始請求先コード
                if (sumAccPaymentListCndtn.Ed_PayeeCode == 0)
                {
                    // 未入力の場合は、最大値をセット
                    sumAccPaymentListCndtnWork.Ed_PayeeCode = 999999;                           // 終了請求先コード
                }
                else
                {
                    sumAccPaymentListCndtnWork.Ed_PayeeCode = sumAccPaymentListCndtn.Ed_PayeeCode; // 終了請求先コード
                }

                sumAccPaymentListCndtnWork.AddUpDate = sumAccPaymentListCndtn.AddUpDate;  // 計上年月日
                sumAccPaymentListCndtnWork.PayDtlDiv = sumAccPaymentListCndtn.PayDtlDiv;  // 支払内訳区分

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 税別内訳印字区分
                sumAccPaymentListCndtnWork.TaxPrintDiv = sumAccPaymentListCndtn.TaxPrintDiv;
                // 税率1
                sumAccPaymentListCndtnWork.TaxRate1 = sumAccPaymentListCndtn.TaxRate1;
                // 税率2
                sumAccPaymentListCndtnWork.TaxRate2 = sumAccPaymentListCndtn.TaxRate2;
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

		#region ◎ 仕入先買掛データ展開処理
		/// <summary>
        /// 仕入先買掛データ展開処理
		/// </summary>
		/// <param name="sumAccPaymentListCndtn">UI抽出条件クラス</param>
		/// <param name="accPaymentTable">展開対象DataTable</param>
        /// <param name="sumAccPaymentListResultWorkList">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 仕入先買掛データを展開する。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2022/10/20</br>
		/// </remarks>
        private void DevListData(SumAccPaymentListCndtn sumAccPaymentListCndtn, DataTable accPaymentTable, ArrayList sumAccPaymentListResultWorkList)
		{
			DataRow dr;
            foreach ( SumAccPaymentListResultWork sumAccPaymentListResultWork in sumAccPaymentListResultWorkList )
			{
                // 出力金額区分チェック
                if (!CheckOutputMoneyDiv(sumAccPaymentListCndtn, sumAccPaymentListResultWork))
                {
                    // 印刷対象データでは無い
                    continue;
                }

                dr = accPaymentTable.NewRow();

                // 抽出結果プロパティ
                dr[PMKAK02025EA.ct_Col_SumAddUpSecCode] = sumAccPaymentListResultWork.SumAddUpSecCode; // 総括計上拠点コード
                dr[PMKAK02025EA.ct_Col_SumSectionGuideNm] = sumAccPaymentListResultWork.SumSectionGuideSnm; // 総括計上拠点名称
                dr[PMKAK02025EA.ct_Col_AddUpSecCode] = sumAccPaymentListResultWork.AddUpSecCode; // 計上拠点コード
                dr[PMKAK02025EA.ct_Col_SectionGuideNm] = sumAccPaymentListResultWork.SectionGuideSnm; // 計上拠点名称

                dr[PMKAK02025EA.ct_Col_SumPayeeCode] = sumAccPaymentListResultWork.SumPayeeCode; // 総括支払先コード
                dr[PMKAK02025EA.ct_Col_SumPayeeSnm] = sumAccPaymentListResultWork.SumPayeeSnm; // 総括支払先略称
                dr[PMKAK02025EA.ct_Col_PayeeCode] = sumAccPaymentListResultWork.PayeeCode; // 支払先コード
                dr[PMKAK02025EA.ct_Col_PayeeSnm] = sumAccPaymentListResultWork.PayeeSnm; // 支払先略称
                dr[PMKAK02025EA.ct_Col_LastTimeAccPay] = sumAccPaymentListResultWork.LastTimeAccPay; // 前回買掛金額
                dr[PMKAK02025EA.ct_Col_ThisTimePayNrml] = sumAccPaymentListResultWork.ThisTimePayNrml; // 今回支払金額（通常支払）
                dr[PMKAK02025EA.ct_Col_ThisTimeFeePayNrml] = sumAccPaymentListResultWork.ThisTimeFeePayNrml; // 今回手数料額（通常支払）
                dr[PMKAK02025EA.ct_Col_ThisTimeDisPayNrml] = sumAccPaymentListResultWork.ThisTimeDisPayNrml; // 今回値引額（通常支払）
                dr[PMKAK02025EA.ct_Col_ThisTimeTtlBlcAcPay] = sumAccPaymentListResultWork.ThisTimeTtlBlcAcPay; // 今回繰越残高（買掛計）
                dr[PMKAK02025EA.ct_Col_OfsThisTimeStock] = sumAccPaymentListResultWork.OfsThisTimeStock; // 相殺後今回仕入金額

                long thisRgdsDisPric = sumAccPaymentListResultWork.ThisRgdsDisPric;
                dr[PMKAK02025EA.ct_Col_ThisRgdsDisPric] = -thisRgdsDisPric; // 返品値引

                dr[PMKAK02025EA.ct_Col_OfsThisStockTax] = sumAccPaymentListResultWork.OfsThisStockTax; // 相殺後今回仕入消費税
                dr[PMKAK02025EA.ct_Col_ThisTimeStockPrice] = sumAccPaymentListResultWork.ThisTimeStockPrice; // 今回仕入金額

                dr[PMKAK02025EA.ct_Col_StckTtlAccPayBalance] = sumAccPaymentListResultWork.StckTtlAccPayBalance; // 仕入合計残高（買掛計）
                dr[PMKAK02025EA.ct_Col_StockSlipCount] = sumAccPaymentListResultWork.StockSlipCount; // 仕入伝票枚数

                dr[PMKAK02025EA.ct_Col_CashPayment] = sumAccPaymentListResultWork.CashPayment; // 現金
                dr[PMKAK02025EA.ct_Col_TrfrPayment] = sumAccPaymentListResultWork.TrfrPayment; // 振込
                dr[PMKAK02025EA.ct_Col_CheckPayment] = sumAccPaymentListResultWork.CheckPayment; // 小切手
                dr[PMKAK02025EA.ct_Col_DraftPayment] = sumAccPaymentListResultWork.DraftPayment; // 手形
                dr[PMKAK02025EA.ct_Col_OffsetPayment] = sumAccPaymentListResultWork.OffsetPayment; // 相殺
                dr[PMKAK02025EA.ct_Col_FundTransferPayment] = sumAccPaymentListResultWork.FundTransferPayment; // 口座振替
                dr[PMKAK02025EA.ct_Col_OthsPayment] = sumAccPaymentListResultWork.OthsPayment; // その他

                // 純仕入額を追加(相殺後今回仕入金額)
                long pureStock = sumAccPaymentListResultWork.OfsThisTimeStock;
                dr[PMKAK02025EA.ct_Col_PureStock] = pureStock;
                
                // 今回合計金額(純仕入額+消費税)
                dr[PMKAK02025EA.ct_Col_StockPricTax] = pureStock + sumAccPaymentListResultWork.OfsThisStockTax;

                // 月次更新チェック
                dr[PMKAK02025EA.Col_MonAddUpNonProc] = CheckMonAddUpNonProc(sumAccPaymentListCndtn, sumAccPaymentListResultWork);

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                // 仕入額(計税率1)
                dr[PMKAK02025EA.ct_Col_TotalThisTimeStockPriceTaxRate1] = sumAccPaymentListResultWork.TotalThisTimeStockPriceTaxRate1;
                // 仕入額(計税率2)
                dr[PMKAK02025EA.ct_Col_TotalThisTimeStockPriceTaxRate2] = sumAccPaymentListResultWork.TotalThisTimeStockPriceTaxRate2;
                // 仕入額(計その他)
                dr[PMKAK02025EA.ct_Col_TotalThisTimeStockPriceOther] = sumAccPaymentListResultWork.TotalThisTimeStockPriceOther;
                // 返品値引(計税率1)
                dr[PMKAK02025EA.ct_Col_TotalThisRgdsDisPricTaxRate1] = sumAccPaymentListResultWork.TotalThisRgdsDisPricTaxRate1;
                // 返品値引(計税率2)
                dr[PMKAK02025EA.ct_Col_TotalThisRgdsDisPricTaxRate2] = sumAccPaymentListResultWork.TotalThisRgdsDisPricTaxRate2;
                // 返品値引(計その他)
                dr[PMKAK02025EA.ct_Col_TotalThisRgdsDisPricOther] = sumAccPaymentListResultWork.TotalThisRgdsDisPricOther;
                // 純仕入額(計税率1)
                dr[PMKAK02025EA.ct_Col_TotalPureStockTaxRate1] = sumAccPaymentListResultWork.TotalPureStockTaxRate1;
                // 純仕入額(計税率2)
                dr[PMKAK02025EA.ct_Col_TotalPureStockTaxRate2] = sumAccPaymentListResultWork.TotalPureStockTaxRate2;
                // 純仕入額(計その他)
                dr[PMKAK02025EA.ct_Col_TotalPureStockOther] = sumAccPaymentListResultWork.TotalPureStockOther;
                // 消費税(計税率1)
                dr[PMKAK02025EA.ct_Col_TotalStockPricTaxTaxRate1] = sumAccPaymentListResultWork.TotalStockPricTaxTaxRate1;
                // 消費税(計税率2)
                dr[PMKAK02025EA.ct_Col_TotalStockPricTaxTaxRate2] = sumAccPaymentListResultWork.TotalStockPricTaxTaxRate2;
                // 消費税(計その他)
                dr[PMKAK02025EA.ct_Col_TotalStockPricTaxOther] = sumAccPaymentListResultWork.TotalStockPricTaxOther;
                // 当月合計(計税率1)
                dr[PMKAK02025EA.ct_Col_TotalStckTtlAccPayBalanceTaxRate1] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceTaxRate1;
                // 当月合計(計税率2)
                dr[PMKAK02025EA.ct_Col_TotalStckTtlAccPayBalanceTaxRate2] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceTaxRate2;
                // 当月合計(計その他)
                dr[PMKAK02025EA.ct_Col_TotalStckTtlAccPayBalanceOther] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceOther;
                // 枚数(計税率1)
                dr[PMKAK02025EA.ct_Col_TotalStockSlipCountTaxRate1] = sumAccPaymentListResultWork.TotalStockSlipCountTaxRate1;
                // 枚数(計税率2)
                dr[PMKAK02025EA.ct_Col_TotalStockSlipCountTaxRate2] = sumAccPaymentListResultWork.TotalStockSlipCountTaxRate2;
                // 枚数(計その他)
                dr[PMKAK02025EA.ct_Col_TotalStockSlipCountOther] = sumAccPaymentListResultWork.TotalStockSlipCountOther;
                // 税率1タイトル
                dr[PMKAK02025EA.ct_Col_TitleTaxRate1] = sumAccPaymentListResultWork.TitleTaxRate1;
                // 税率2タイトル
                dr[PMKAK02025EA.ct_Col_TitleTaxRate2] = sumAccPaymentListResultWork.TitleTaxRate2;
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
                // --- ADD START 3H 仰亮亮 2022/10/20 ----->>>>>
                // 仕入額(計非課税)
                dr[PMKAK02025EA.Col_TotalThisTimeStockPriceTaxFree] = sumAccPaymentListResultWork.TotalThisTimeStockPriceTaxFree;
                // 返品値引(計非課税)
                dr[PMKAK02025EA.Col_TotalThisRgdsDisPricTaxFree] = sumAccPaymentListResultWork.TotalThisRgdsDisPricTaxFree;
                // 純仕入額(計非課税)
                dr[PMKAK02025EA.Col_TotalPureStockTaxFree] = sumAccPaymentListResultWork.TotalPureStockTaxFree;
                // 消費税(計非課税)
                dr[PMKAK02025EA.Col_TotalStockPricTaxTaxFree] = sumAccPaymentListResultWork.TotalStockPricTaxTaxFree;
                // 当月合計(計非課税)
                dr[PMKAK02025EA.Col_TotalStckTtlAccPayBalanceTaxFree] = sumAccPaymentListResultWork.TotalStckTtlAccPayBalanceTaxFree;
                // 枚数(計非課税)
                dr[PMKAK02025EA.Col_TotalStockSlipCountTaxFree] = sumAccPaymentListResultWork.TotalStockSlipCountTaxFree;
                // --- ADD END 3H 仰亮亮 2022/10/20 -----<<<<<

                // TableにAdd
				accPaymentTable.Rows.Add( dr );
			}
		}
		#endregion

        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="sumAccPaymentListCndtn">UI抽出条件クラス</param>
        /// <param name="sumAccPaymentListResultWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力金額区分で今回支払額をチェックする。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(SumAccPaymentListCndtn sumAccPaymentListCndtn, SumAccPaymentListResultWork sumAccPaymentListResultWork)
        {
            bool bRet = false;

            // 出力金額区分で仕入合計残高のチェック
            switch (sumAccPaymentListCndtn.OutMoneyDiv)
            {
                case SumAccPaymentListCndtn.OutMoneyDivState.All: // 全て出力 
                    {
                        bRet = true;
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.ZeroPlus: // ０とプラス金額を出力
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance >= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.Plus: // プラス金額のみ出力
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance > 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.Zero: // ０のみ出力
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance == 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.PlusMinus: // プラス金額とマイナス金額を出力
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance != 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.ZeroMinus: // ０とマイナス金額を出力
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance <= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case SumAccPaymentListCndtn.OutMoneyDivState.Minus: // マイナス金額のみ出力
                    {
                        if (sumAccPaymentListResultWork.StckTtlAccPayBalance < 0)
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
        /// <param name="sumAccPaymentListCndtn">UI抽出条件クラス</param>
        /// <param name="sumAccPaymentListResultWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 拠点毎の月次締未更新チェックを行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2012/11/07</br>
        /// </remarks>
        private bool CheckMonAddUpNonProc(SumAccPaymentListCndtn sumAccPaymentListCndtn, SumAccPaymentListResultWork sumAccPaymentListResultWork)
        {
            bool retb = false;
            string key = sumAccPaymentListResultWork.AddUpSecCode.TrimEnd();

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
                totalDayCalculator.InitializeHisMonthlyAccPay();
                totalDayCalculator.GetHisTotalDayMonthlyAccPay(key, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

                if (prevTotalMonth == DateTime.MinValue)
                {
                    // 月次締未更新
                    _monAddUpNonProcDic.Add(key, true);
                    retb = true;

                }
                else
                {
                    // 月次締更新
                    if (prevTotalMonth < sumAccPaymentListCndtn.AddUpYearMonth)
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
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
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
