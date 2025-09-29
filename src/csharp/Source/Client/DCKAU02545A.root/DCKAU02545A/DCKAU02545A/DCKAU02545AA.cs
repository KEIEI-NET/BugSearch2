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
    /// 売掛残高一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高一覧表で使用するデータを取得する。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.10.24</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.01</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/02/28</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 11800255-00　インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2022/09/19</br>  
    /// </remarks>
	public class CustAccRecMainAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
		public CustAccRecMainAcs()
		{
            this._iBillBalanceTableDB = (IBillBalanceTableDB)MediationBillBalanceTableDB.GetBillBalanceTableDB();
		}

		/// <summary>
		/// 売掛残高一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売掛残高一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
		static CustAccRecMainAcs()
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
        IBillBalanceTableDB _iBillBalanceTableDB;

		private DataSet _custAccRecDs;				    // 得意先売掛データセット

        // 2009.02.10 30413 犬飼 拠点毎に月次締未更新キャッシュ >>>>>>START
        private Dictionary<string, bool> _monAddUpNonProcDic;
        // 2009.02.10 30413 犬飼 拠点毎に月次締未更新キャッシュ <<<<<<END
                
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
        /// 得意先売掛金額データセット(読み取り専用)
		/// </summary>
		public DataSet CustAccRecDs
		{
			get{ return this._custAccRecDs; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
        #region ◎ 得意先売掛金額データ取得
        /// <summary>
        /// 得意先売掛金額データ取得
		/// </summary>
        /// <param name="custaccrecmainCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する得意先売掛金額データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
        public int SearchCustAccRecMain(CustAccRecMainCndtn custaccrecmainCndtn, out string errMsg)
		{
            return this.SearchCustAccRecMainProc(custaccrecmainCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
        #region ◎ 得意先売掛金額データ取得
        /// <summary>
        /// 得意先売掛金額データ取得
		/// </summary>
        /// <param name="custAccRecMainCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
        private int SearchCustAccRecMainProc(CustAccRecMainCndtn custAccRecMainCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAU02544EA.CreateDataTableCustAccRecMain(ref this._custAccRecDs);
                ExtrInfo_BillBalanceWork extrInfo_BillBalanceWork = new ExtrInfo_BillBalanceWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevCustAccRecMainCndtn(custAccRecMainCndtn, out extrInfo_BillBalanceWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retCustAccRecMainList = null;
                // 2008.10.01 30413 犬飼 検索メソッドの変更 >>>>>>START
                //status = this._iBillBalanceTableDB.SearchBillBalanceTable( out retCustAccRecMainList, extrInfo_BillBalanceWork );
                status = this._iBillBalanceTableDB.Search(out retCustAccRecMainList, extrInfo_BillBalanceWork, 0, ConstantManagement.LogicalMode.GetData0);
                // 2008.10.01 30413 犬飼 検索メソッドの変更 <<<<<<END

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 2009.02.10 30413 犬飼 キャッシュの初期化 >>>>>>START
                        _monAddUpNonProcDic = new Dictionary<string, bool>();
                        // 2009.02.10 30413 犬飼 キャッシュの初期化 <<<<<<END
                        
                        // データ展開処理
                        DevCustAccRecMainData(custAccRecMainCndtn, this._custAccRecDs.Tables[DCKAU02544EA.Col_Tbl_CustAccRecMain], (ArrayList)retCustAccRecMainList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._custAccRecDs.Tables[DCKAU02544EA.Col_Tbl_CustAccRecMain].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
                        errMsg = "得意先売掛金額データの取得に失敗しました。";
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
		/// <param name="custAccRecMainCndtn">UI抽出条件クラス</param>
		/// <param name="extrInfo_BillBalanceWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/02/28</br>
        private int DevCustAccRecMainCndtn(CustAccRecMainCndtn custAccRecMainCndtn, out ExtrInfo_BillBalanceWork extrInfo_BillBalanceWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            extrInfo_BillBalanceWork = new ExtrInfo_BillBalanceWork();

			try
			{
				extrInfo_BillBalanceWork.EnterpriseCode = custAccRecMainCndtn.EnterpriseCode;

				// 2008.10.01 30413 犬飼 抽出条件プロパティの変更 >>>>>>START
                // 企業コード
				// 抽出条件パラメータセット
                if (custAccRecMainCndtn.CollectAddupSecCodeList.Length != 0)
				{
					if ( custAccRecMainCndtn.IsSelectAllSection )
					{
						// 全社の時
                        //extrInfo_BillBalanceWork.CollectAddupSecCodeList = null;
                        extrInfo_BillBalanceWork.SectionCodes = null;
					}
					else
					{
                        //extrInfo_BillBalanceWork.CollectAddupSecCodeList = custAccRecMainCndtn.CollectAddupSecCodeList;
                        extrInfo_BillBalanceWork.SectionCodes = custAccRecMainCndtn.CollectAddupSecCodeList;
					}
				}
				else
				{
                    //extrInfo_BillBalanceWork.CollectAddupSecCodeList = null;
                    extrInfo_BillBalanceWork.SectionCodes = null;
				}

                extrInfo_BillBalanceWork.AddUpDate = custAccRecMainCndtn.AddUpDate;                    // 計上年月日
                //extrInfo_BillBalanceWork.CollectAddUpYearMonth = custAccRecMainCndtn.AddUpYearMonth;   // 対象年月
                extrInfo_BillBalanceWork.AddUpYearMonth = custAccRecMainCndtn.AddUpYearMonth;          // 対象年月
                extrInfo_BillBalanceWork.SortOrderDiv = (int)custAccRecMainCndtn.SortOrderDiv;         // 出力順
                extrInfo_BillBalanceWork.St_ClaimCode = custAccRecMainCndtn.St_ClaimCode;	           // 開始請求先コード
                if (custAccRecMainCndtn.Ed_ClaimCode == 0)
                {
                    // 未入力の場合は、最大値をセット
                    extrInfo_BillBalanceWork.Ed_ClaimCode = 99999999;	           // 終了請求先コード
                }
                else
                {
                    extrInfo_BillBalanceWork.Ed_ClaimCode = custAccRecMainCndtn.Ed_ClaimCode;	           // 終了請求先コード
                }
                //extrInfo_BillBalanceWork.St_ClaimKana = custAccRecMainCndtn.St_ClaimKana;	           // 開始請求先カナ
                //extrInfo_BillBalanceWork.Ed_ClaimKana = custAccRecMainCndtn.Ed_ClaimKana;	           // 終了請求先先カナ
                extrInfo_BillBalanceWork.St_SalesAreaCode = custAccRecMainCndtn.St_SalesAreaCode;	   // 開始販売エリアコード
                // 2008.11.19 30413 犬飼 終了販売エリアの設定を修正 >>>>>>START
                //extrInfo_BillBalanceWork.Ed_SalesAreaCode = custAccRecMainCndtn.Ed_SalesAreaCode;	   // 終了販売エリアコード
                if (custAccRecMainCndtn.Ed_SalesAreaCode == 0)
                {
                    // 未入力の場合は、最大値をセット
                    extrInfo_BillBalanceWork.Ed_SalesAreaCode = 9999;               // 終了販売エリアコード
                }
                else
                {
                    extrInfo_BillBalanceWork.Ed_SalesAreaCode = custAccRecMainCndtn.Ed_SalesAreaCode;	   // 終了販売エリアコード
                }
                // 2008.11.19 30413 犬飼 終了販売エリアの設定を修正 <<<<<<END
                extrInfo_BillBalanceWork.EmployeeKindDiv = (int)custAccRecMainCndtn.EmployeeKindDiv;   // 担当者区分
                extrInfo_BillBalanceWork.St_EmployeeCode = custAccRecMainCndtn.St_EmployeeCode;        // 開始担当者コード
                extrInfo_BillBalanceWork.Ed_EmployeeCode = custAccRecMainCndtn.Ed_EmployeeCode;	       // 終了担当者コード
                // 2009.02.10 30413 犬飼 出力金額区分はUI側で処理 >>>>>>START
                //extrInfo_BillBalanceWork.OutMoneyDiv = (int)custAccRecMainCndtn.OutMoneyDiv;           // 出力金額区分
                // 2009.02.10 30413 犬飼 出力金額区分はUI側で処理 <<<<<<END
                extrInfo_BillBalanceWork.DepoDtlDiv = custAccRecMainCndtn.DepoDtlDiv;
                // 2008.10.01 30413 犬飼 抽出条件プロパティの変更 <<<<<<END

                // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
                // 税別内訳印字区分
                extrInfo_BillBalanceWork.TaxPrintDiv = custAccRecMainCndtn.TaxPrintDiv;
                // 税率1
                extrInfo_BillBalanceWork.TaxRate1 = custAccRecMainCndtn.TaxRate1;
                // 税率2
                extrInfo_BillBalanceWork.TaxRate2 = custAccRecMainCndtn.TaxRate2;
                // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 得意先売掛データ展開処理
		/// <summary>
        /// 得意先売掛データ展開処理
		/// </summary>
		/// <param name="custAccRecMainCndtn">UI抽出条件クラス</param>
		/// <param name="custAccRecMainDt">展開対象DataTable</param>
		/// <param name="custAccRecMainWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 得意先売掛データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.24</br>
        /// <br>UpdateNote : 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/02/28</br>
		/// </remarks>
        private void DevCustAccRecMainData(CustAccRecMainCndtn custAccRecMainCndtn, DataTable custAccRecMainDt, ArrayList custAccRecMainWork)
		{
			DataRow dr;
            foreach (RsltInfo_BillBalanceWork custAccRecmainResWork in custAccRecMainWork)
			{
                // 出力金額区分チェック
                if (!CheckOutputMoneyDiv(custAccRecMainCndtn, custAccRecmainResWork))
                {
                    // 印刷対象データでは無い
                    continue;
                }

                dr = custAccRecMainDt.NewRow();

                // 2008.10.01 30413 犬飼 抽出結果プロパティの変更 >>>>>>START
                // 計上拠点コード
                dr[DCKAU02544EA.Col_AddUpSecCode] = custAccRecmainResWork.AddUpSecCode;
                //// 計上拠点名称
                //if ( custAccRecMainCndtn.IsSelectAllSection)
                //    dr[DCKAU02544EA.Col_AddUpSecName] = "全社";
                //else
                //dr[DCKAU02544EA.Col_AddUpSecName] = custAccRecmainResWork.AddUpSecName.TrimEnd();
                dr[DCKAU02544EA.Col_AddUpSecName] = custAccRecmainResWork.SectionGuideSnm.TrimEnd();
                //// 計上拠点名称(明細)
                //dr[DCKAU02544EA.Col_AddUpSecName_Detail] = custAccRecmainResWork.AddUpSecName.TrimEnd();
                // 請求先コード
                dr[DCKAU02544EA.Col_ClaimCode] = custAccRecmainResWork.ClaimCode;
                // 請求先名称
                //dr[DCKAU02544EA.Col_ClaimName] = custAccRecmainResWork.ClaimName;
                //// 請求先名称2
                //dr[DCKAU02544EA.Col_ClaimName2] = custAccRecmainResWork.ClaimName2;
                //// 請求先カナ
                //dr[DCKAU02544EA.Col_ClaimKana] = custAccRecmainResWork.ClaimKana;
                // 請求先略称
                dr[DCKAU02544EA.Col_ClaimSnm] = custAccRecmainResWork.ClaimSnm;
                //// 集金担当従業員コード
                //dr[DCKAU02544EA.Col_BillCollecterCd] = custAccRecmainResWork.BillCollecterCd;
                //// 集金担当従業員名称
                //dr[DCKAU02544EA.Col_BillCollecterNm] = custAccRecmainResWork.BillCollecterNm;
                //// 顧客担当従業員コード
                //dr[DCKAU02544EA.Col_CustomerAgentCd] = custAccRecmainResWork.CustomerAgentCd;
                //// 顧客担当従業員名称
                //dr[DCKAU02544EA.Col_CustomerAgentNm] = custAccRecmainResWork.CustomerAgentNm;
                // 販売エリアコード
                dr[DCKAU02544EA.Col_SalesAreaCode] = custAccRecmainResWork.SalesAreaCode;
                // 販売エリア名称
                dr[DCKAU02544EA.Col_SalesAreaName] = custAccRecmainResWork.SalesAreaName;
                //// 計上年月日(表示用)
                //dr[DCKAU02544EA.Col_AddUpDate] = TDateTime.DateTimeToString(CustAccRecMainCndtn.ct_DateFomat, custAccRecmainResWork.AddUpDate);
                //// 計上年月日(ソート用)
                //dr[DCKAU02544EA.Col_Sort_AddUpDate] = TDateTime.DateTimeToLongDate(custAccRecmainResWork.AddUpDate);
                //// 計上年月(表示用)
                //dr[DCKAU02544EA.Col_AddUpYearMonth] = TDateTime.DateTimeToString(CustAccRecMainCndtn.ct_DateFomat, custAccRecmainResWork.AddUpYearMonth);
                //// 計上年月(ソート用)
                //dr[DCKAU02544EA.Col_Sort_AddUpYearMonth] = TDateTime.DateTimeToLongDate(custAccRecmainResWork.AddUpYearMonth);
                // 前回売掛金額
                dr[DCKAU02544EA.Col_LastTimeAccRec] = custAccRecmainResWork.LastTimeAccRec;
                // 今回入金金額
                dr[DCKAU02544EA.Col_ThisTimeDmdNrml] = custAccRecmainResWork.ThisTimeDmdNrml;
                // 今回繰越残高
                dr[DCKAU02544EA.Col_ThisTimeTtlBlcAcc] = custAccRecmainResWork.ThisTimeTtlBlcAcc;
                // 相殺後今回売上金額
                dr[DCKAU02544EA.Col_OfsThisTimeSales] = custAccRecmainResWork.OfsThisTimeSales;
                // 2009.02.05 30413 犬飼 符号を逆に修正 >>>>>>START
                // 返品値引
                //dr[DCKAU02544EA.Col_ThisRgdsDisPric] = custAccRecmainResWork.ThisRgdsDisPric;
                long thisRgdsDisPric = custAccRecmainResWork.ThisRgdsDisPric;
                dr[DCKAU02544EA.Col_ThisRgdsDisPric] = -thisRgdsDisPric;
                // 2009.02.05 30413 犬飼 符号を逆に修正 <<<<<<END
                // 相殺後今回売上消費税
                dr[DCKAU02544EA.Col_OfsThisSalesTax] = custAccRecmainResWork.OfsThisSalesTax;
                // 2009.01.27 30413 犬飼 今回売上金額の復活 >>>>>>START
                // 今回売上金額
                dr[DCKAU02544EA.Col_ThisTimeSales] = custAccRecmainResWork.ThisTimeSales;
                // 2009.01.27 30413 犬飼 今回売上金額の復活 <<<<<<END
                //// 今回売上返品金額
                //dr[DCKAU02544EA.Col_ThisSalesPricRgds] = custAccRecmainResWork.ThisSalesPricRgds;
                //// 今回売上値引金額
                //dr[DCKAU02544EA.Col_ThisSalesPricDis] = custAccRecmainResWork.ThisSalesPricDis;
                //// 今回支払相殺金額
                //dr[DCKAU02544EA.Col_ThisPayOffset] = custAccRecmainResWork.ThisPayOffset;
                //// 消費税調整額
                //dr[DCKAU02544EA.Col_TaxAdjust] = custAccRecmainResWork.TaxAdjust;
                //// 残高調整額
                //dr[DCKAU02544EA.Col_BalanceAdjust] = custAccRecmainResWork.BalanceAdjust;
                // 計算後当月売掛金額
                dr[DCKAU02544EA.Col_AfCalTMonthAccRec] = custAccRecmainResWork.AfCalTMonthAccRec;
                // 伝票枚数
                dr[DCKAU02544EA.Col_SalesSlipCount] = custAccRecmainResWork.SalesSlipCount;
                //// 今回売上返品・値引
                //dr[DCKAU02544EA.Col_ThisSalesPricRgdsDis] = custAccRecmainResWork.ThisSalesPricRgds + custAccRecmainResWork.ThisSalesPricDis;
                //// 当月合計
                //dr[DCKAU02544EA.Col_SalesPricTax] = custAccRecmainResWork.OfsThisTimeSales + custAccRecmainResWork.OfsThisSalesTax;
                // 担当者コード
                dr[DCKAU02544EA.Col_AgentCd] = custAccRecmainResWork.AgentCd;
                // 担当者名
                dr[DCKAU02544EA.Col_Name] = custAccRecmainResWork.Name;
                // 手数料
                dr[DCKAU02544EA.Col_ThisTimeFeeDmdNrml] = custAccRecmainResWork.ThisTimeFeeDmdNrml;
                // 値引
                dr[DCKAU02544EA.Col_ThisTimeDisDmdNrml] = custAccRecmainResWork.ThisTimeDisDmdNrml;
                // 現金
                dr[DCKAU02544EA.Col_CashDeposit] = custAccRecmainResWork.CashDeposit;
                // 振込
                dr[DCKAU02544EA.Col_TrfrDeposit] = custAccRecmainResWork.TrfrDeposit;
                // 小切手
                dr[DCKAU02544EA.Col_CheckDeposit] = custAccRecmainResWork.CheckDeposit;
                // 手形
                dr[DCKAU02544EA.Col_DraftDeposit] = custAccRecmainResWork.DraftDeposit;
                // 相殺
                dr[DCKAU02544EA.Col_OffsetDeposit] = custAccRecmainResWork.OffsetDeposit;
                // 口座振替
                dr[DCKAU02544EA.Col_FundTransferDeposit] = custAccRecmainResWork.FundTransferDeposit;
                // その他
                dr[DCKAU02544EA.Col_OthsDeposit] = custAccRecmainResWork.OthsDeposit;

                // 2009.01.29 30413 犬飼 純売上額の計算を変更 >>>>>>START
                // 2009.01.27 30413 犬飼 純売上額の計算を変更 >>>>>>START
                //// 純売上額を追加(相殺後今回売上金額+返品値引)
                //long pureSales = custAccRecmainResWork.OfsThisTimeSales + custAccRecmainResWork.ThisRgdsDisPric;
                //// 純売上額を追加(売上金額+返品値引)
                //long pureSales = custAccRecmainResWork.ThisTimeSales + custAccRecmainResWork.ThisRgdsDisPric;
                // 純売上額を追加(相殺後今回売上金額)
                long pureSales = custAccRecmainResWork.OfsThisTimeSales;                
                dr[DCKAU02544EA.ct_Col_PureSales] = pureSales;
                // 2009.01.27 30413 犬飼 純売上額の計算を変更 <<<<<<END
                // 2009.01.29 30413 犬飼 純売上額の計算を変更 <<<<<<END
                
                // 2009.01.29 30413 犬飼 当月合計の計算を変更 >>>>>>START
                //// 当月合計
                //dr[DCKAU02544EA.Col_SalesPricTax] = custAccRecmainResWork.ThisTimeTtlBlcAcc + pureSales + custAccRecmainResWork.OfsThisSalesTax;
                dr[DCKAU02544EA.Col_SalesPricTax] = pureSales + custAccRecmainResWork.OfsThisSalesTax;
                // 2009.01.29 30413 犬飼 当月合計の計算を変更 <<<<<<END
                
                // 2008.10.01 30413 犬飼 抽出結果プロパティの変更 <<<<<<END

                // 2009.02.10 30413 犬飼 拠点毎に暫定消費税の文言を表示制御 >>>>>>START
                // 月次締未更新チェック
                dr[DCKAU02544EA.Col_MonAddUpNonProc] = CheckMonAddUpNonProc(custAccRecMainCndtn, custAccRecmainResWork);
                // 2009.02.10 30413 犬飼 拠点毎に暫定消費税の文言を表示制御 <<<<<<END

                // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
                // 売上額(計税率1)
                dr[DCKAU02544EA.Col_TotalThisTimeSalesTaxRate1] = custAccRecmainResWork.TotalThisTimeSalesTaxRate1;
                // 売上額(計税率2)
                dr[DCKAU02544EA.Col_TotalThisTimeSalesTaxRate2] = custAccRecmainResWork.TotalThisTimeSalesTaxRate2;
                // 売上額(計その他)
                dr[DCKAU02544EA.Col_TotalThisTimeSalesOther] = custAccRecmainResWork.TotalThisTimeSalesOther;
                // 返品値引(計税率1)
                dr[DCKAU02544EA.Col_TotalThisRgdsDisPricTaxRate1] = custAccRecmainResWork.TotalThisRgdsDisPricTaxRate1;
                // 返品値引(計税率2)
                dr[DCKAU02544EA.Col_TotalThisRgdsDisPricTaxRate2] = custAccRecmainResWork.TotalThisRgdsDisPricTaxRate2;
                // 返品値引(計その他)
                dr[DCKAU02544EA.Col_TotalThisRgdsDisPricOther] = custAccRecmainResWork.TotalThisRgdsDisPricOther;
                // 純売上額(計税率1)
                dr[DCKAU02544EA.Col_TotalPureSalesTaxRate1] = custAccRecmainResWork.TotalPureSalesTaxRate1;
                // 純売上額(計税率2)
                dr[DCKAU02544EA.Col_TotalPureSalesTaxRate2] = custAccRecmainResWork.TotalPureSalesTaxRate2;
                // 純売上額(計その他)
                dr[DCKAU02544EA.Col_TotalPureSalesOther] = custAccRecmainResWork.TotalPureSalesOther;
                // 消費税(計税率1)
                dr[DCKAU02544EA.Col_TotalSalesPricTaxTaxRate1] = custAccRecmainResWork.TotalSalesPricTaxTaxRate1;
                // 消費税(計税率2)
                dr[DCKAU02544EA.Col_TotalSalesPricTaxTaxRate2] = custAccRecmainResWork.TotalSalesPricTaxTaxRate2;
                // 消費税(計その他)
                dr[DCKAU02544EA.Col_TotalSalesPricTaxOther] = custAccRecmainResWork.TotalSalesPricTaxOther;
                // 当月合計(計税率1)
                dr[DCKAU02544EA.Col_TotalAfCalTMonthAccRecTaxRate1] = custAccRecmainResWork.TotalAfCalTMonthAccRecTaxRate1;
                // 当月合計(計税率2)
                dr[DCKAU02544EA.Col_TotalAfCalTMonthAccRecTaxRate2] = custAccRecmainResWork.TotalAfCalTMonthAccRecTaxRate2;
                // 当月合計(計その他)
                dr[DCKAU02544EA.Col_TotalAfCalTMonthAccRecOther] = custAccRecmainResWork.TotalAfCalTMonthAccRecOther;
                // 枚数(計税率1)
                dr[DCKAU02544EA.Col_TotalSalesSlipCountTaxRate1] = custAccRecmainResWork.TotalSalesSlipCountTaxRate1;
                // 枚数(計税率2)
                dr[DCKAU02544EA.Col_TotalSalesSlipCountTaxRate2] = custAccRecmainResWork.TotalSalesSlipCountTaxRate2;
                // 枚数(計その他)
                dr[DCKAU02544EA.Col_TotalSalesSlipCountOther] = custAccRecmainResWork.TotalSalesSlipCountOther;
                // 税率1タイトル
                dr[DCKAU02544EA.Col_TitleTaxRate1] = custAccRecmainResWork.TitleTaxRate1;
                // 税率2タイトル
                dr[DCKAU02544EA.Col_TitleTaxRate2] = custAccRecmainResWork.TitleTaxRate2;
                // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<
                // --- ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                // 売上額(計非課税)
                dr[DCKAU02544EA.Col_TotalThisTimeSalesTaxFree] = custAccRecmainResWork.TotalThisTimeSalesTaxFree;
                // 返品値引(計非課税)
                dr[DCKAU02544EA.Col_TotalThisRgdsDisPricTaxFree] = custAccRecmainResWork.TotalThisRgdsDisPricTaxFree;
                // 純売上額((計非課税)
                dr[DCKAU02544EA.Col_TotalPureSalesTaxFree] = custAccRecmainResWork.TotalPureSalesTaxFree;
                // 消費税(計非課税)
                dr[DCKAU02544EA.Col_TotalSalesPricTaxTaxFree] = custAccRecmainResWork.TotalSalesPricTaxTaxFree;
                // 当月合計(計非課税)
                dr[DCKAU02544EA.Col_TotalAfCalTMonthAccRecTaxFree] = custAccRecmainResWork.TotalAfCalTMonthAccRecTaxFree;
                // 枚数(計非課税)
                dr[DCKAU02544EA.Col_TotalSalesSlipCountTaxFree] = custAccRecmainResWork.TotalSalesSlipCountTaxFree;
                // --- ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
            
                // TableにAdd
				custAccRecMainDt.Rows.Add( dr );
			}
		}
		#endregion

        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="custAccRecMainCndtn">UI抽出条件クラス</param>
        /// <param name="custAccRecmainResWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力金額区分で今回入金額をチェックする。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(CustAccRecMainCndtn custAccRecMainCndtn, RsltInfo_BillBalanceWork custAccRecmainResWork)
        {
            bool bRet = false;

            // 2009.02.10 30413 犬飼 計算後当月売掛金額に修正 >>>>>>START
            //// 出力金額区分で今回支払額のチェック
            // 出力金額区分で計算後当月売掛金額のチェック
            switch (custAccRecMainCndtn.OutMoneyDiv)
            {
                case CustAccRecMainCndtn.OutMoneyDivState.All: // 全て出力 
                    {
                        bRet = true;
                        break;
                    }
                case CustAccRecMainCndtn.OutMoneyDivState.ZeroPlus: // ０とプラス金額を出力
                    {
                        //if (custAccRecmainResWork.ThisTimeDmdNrml >= 0)
                        if (custAccRecmainResWork.AfCalTMonthAccRec >= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case CustAccRecMainCndtn.OutMoneyDivState.Plus: // プラス金額のみ出力
                    {
                        //if (custAccRecmainResWork.ThisTimeDmdNrml > 0)
                        if (custAccRecmainResWork.AfCalTMonthAccRec > 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case CustAccRecMainCndtn.OutMoneyDivState.Zero: // ０のみ出力
                    {
                        //if (custAccRecmainResWork.ThisTimeDmdNrml == 0)
                        if (custAccRecmainResWork.AfCalTMonthAccRec == 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case CustAccRecMainCndtn.OutMoneyDivState.PlusMinus: // プラス金額とマイナス金額を出力
                    {
                        //if (custAccRecmainResWork.ThisTimeDmdNrml != 0)
                        if (custAccRecmainResWork.AfCalTMonthAccRec != 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case CustAccRecMainCndtn.OutMoneyDivState.ZeroMinus: // ０とマイナス金額を出力
                    {
                        //if (custAccRecmainResWork.ThisTimeDmdNrml <= 0)
                        if (custAccRecmainResWork.AfCalTMonthAccRec <= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case CustAccRecMainCndtn.OutMoneyDivState.Minus: // マイナス金額のみ出力
                    {
                        //if (custAccRecmainResWork.ThisTimeDmdNrml < 0)
                        if (custAccRecmainResWork.AfCalTMonthAccRec < 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                default:
                    break;
            }
            // 2009.02.10 30413 犬飼 計算後当月売掛金額に修正 <<<<<<END
            
            return bRet;
        }

        /// <summary>
        /// 月次締未更新チェック
        /// </summary>
        /// <param name="custAccRecMainCndtn">UI抽出条件クラス</param>
        /// <param name="custAccRecmainResWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 拠点毎の月次締未更新チェックを行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.10</br>
        /// </remarks>
        private bool CheckMonAddUpNonProc(CustAccRecMainCndtn custAccRecMainCndtn, RsltInfo_BillBalanceWork custAccRecmainResWork)
        {
            bool retb = false;
            string key = custAccRecmainResWork.AddUpSecCode.TrimEnd();

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
                    if (prevTotalMonth < custAccRecMainCndtn.AddUpYearMonth)
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
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.24</br>
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
