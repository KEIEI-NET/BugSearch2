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
    /// 売掛残高元帳アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛残高元帳で使用するデータを取得する。</br>
    /// <br>Programmer : 矢田 敬吾</br>
    /// <br>Date       : 2007.11.19</br>
    /// <br>UpdateNote : 2008/12/11 30414 忍 幸史 Partsman用に変更</br>
    /// <br>Update Note: 2009/02/21 30452 上野 俊治</br>
    /// <br>            ・障害対応11740 返品・値引きは正で印字するように修正。純売上額の計算を修正。</br>
    /// <br>Update Note: 2009/02/24 30452 上野 俊治</br>
    /// <br>            ・障害対応11740 税込売上額の計算を修正。</br>
    /// <br>Update Note: 2014/02/26 田建委</br>
    /// <br>           : Redmine#42188 出力金額区分追加</br>
    /// </remarks>
	public class DmdBalanceAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 売掛残高元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高元帳アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 矢田 敬吾</br>
	    /// <br>Date       : 2007.11.19</br>
		/// </remarks>
		public DmdBalanceAcs()
		{
            //this._iDemandBalanceLedgerDB = (IDemandBalanceLedgerDB)MediationDemandBalanceLedgerDB.GetDemandBalanceLedgerDB();
            this._iDemandBalanceLedgerDB = (IAccRecBalanceLedgerDB)MediationAccRecBalanceLedgerDB.GetAccRecBalanceLedgerDB();
		}

		/// <summary>
        /// 売掛残高元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高元帳アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 矢田 敬吾</br>
	    /// <br>Date       : 2007.11.19</br>
		/// </remarks>
		static DmdBalanceAcs()
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
        //IDemandBalanceLedgerDB _iDemandBalanceLedgerDB;

        IAccRecBalanceLedgerDB _iDemandBalanceLedgerDB;

		private DataSet _dmdBalanceDs;				    // 残高元帳データセット

        //private string _addUpSecCode = "";
        //private Int32 _claimCode = 0;
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
        /// 残高元帳データセット(読み取り専用)
		/// </summary>
		public DataSet DmdBalanceDs
		{
			get{ return this._dmdBalanceDs; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
        #region ◎ 残高元帳データ取得
        /// <summary>
		/// データ取得
		/// </summary>
        /// <param name="extrInfo_AccRecBalance">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する残高元帳データを取得する。</br>
        /// <br>Programmer : 矢田 敬吾</br>
	    /// <br>Date       : 2007.11.19</br>
		/// </remarks>
        public int SearchDmdBalance(ExtrInfo_AccRecBalance extrInfo_AccRecBalance, out string errMsg)
		{
            return this.SearchDmdBalanceProc(extrInfo_AccRecBalance, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 仕入先支払データ取得
		/// <summary>
		/// データ取得
		/// </summary>
        /// <param name="extrInfo_AccRecBalance"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 矢田 敬吾</br>
	    /// <br>Date       : 2007.11.19</br>
		/// </remarks>
        private int SearchDmdBalanceProc(ExtrInfo_AccRecBalance extrInfo_AccRecBalance, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                //DCKAU02584EA.CreateDataTableDmdBalanceMain(ref this._dmdBalanceDs);
                DCKAU02604EA.CreateDataTableDmdBalanceMain(ref this._dmdBalanceDs);

                //ExtrInfo_DemandBalanceWork extrInfo_DemandBalanceWork = new ExtrInfo_DemandBalanceWork();
                ExtrInfo_AccRecBalanceWork extrInfo_DemandBalanceWork = new ExtrInfo_AccRecBalanceWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevDmdBalance(extrInfo_AccRecBalance, out extrInfo_DemandBalanceWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retDemandBalanceList = null;
                //status = this._iDemandBalanceLedgerDB.SearchDemandBalanceLedger( out retDemandBalanceList, extrInfo_DemandBalanceWork );
                status = this._iDemandBalanceLedgerDB.SearchAccRecBalanceLedger(out retDemandBalanceList, extrInfo_DemandBalanceWork);
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

						// データ展開処理
                        DevDmdBalanceData(extrInfo_AccRecBalance, this._dmdBalanceDs.Tables[DCKAU02604EA.Col_Tbl_DmdBalance], (ArrayList)retDemandBalanceList);

                        if (this._dmdBalanceDs.Tables[DCKAU02604EA.Col_Tbl_DmdBalance].DefaultView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }

                            break;
						
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "売掛残高元帳データの取得に失敗しました。";
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
        /// <param name="extrInfo_AccRecBalance">UI抽出条件クラス</param>
		/// <param name="extrInfo_DemandBalanceWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevDmdBalance(ExtrInfo_AccRecBalance extrInfo_AccRecBalance, out ExtrInfo_AccRecBalanceWork extrInfo_DemandBalanceWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            //extrInfo_DemandBalanceWork = new ExtrInfo_DemandBalanceWork();
            extrInfo_DemandBalanceWork = new ExtrInfo_AccRecBalanceWork();

			try
			{
				extrInfo_DemandBalanceWork.EnterpriseCode = extrInfo_AccRecBalance.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //if (extrInfo_AccRecBalance.DmdAddupSecCodeList.Length != 0)
                if (extrInfo_AccRecBalance.SectionCodes.Length != 0)
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
                {
					if ( extrInfo_AccRecBalance.IsSelectAllSection )
					{
						// 全社の時
                        extrInfo_DemandBalanceWork.SectionCodes = null;
					}
					else
					{
                        // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                        //extrInfo_DemandBalanceWork.SectionCodes = extrInfo_AccRecBalance.DmdAddupSecCodeList;
                        extrInfo_DemandBalanceWork.SectionCodes = extrInfo_AccRecBalance.SectionCodes;
                        // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
                    }
				}
				else
				{
                    extrInfo_DemandBalanceWork.SectionCodes = null;
				}

                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //extrInfo_DemandBalanceWork.St_AddUpYearMonth = extrInfo_AccRecBalance.St_AddUpYearMonth;// 開始処理月
                //extrInfo_DemandBalanceWork.Ed_AddUpYearMonth = extrInfo_AccRecBalance.Ed_AddUpYearMonth;// 終了処理月
                extrInfo_DemandBalanceWork.St_AddUpYearMonth = TDateTime.LongDateToDateTime(extrInfo_AccRecBalance.St_AddUpYearMonth);// 開始処理月
                extrInfo_DemandBalanceWork.Ed_AddUpYearMonth = TDateTime.LongDateToDateTime(extrInfo_AccRecBalance.Ed_AddUpYearMonth);// 終了処理月
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<

                extrInfo_DemandBalanceWork.St_ClaimCode = extrInfo_AccRecBalance.St_ClaimCode;// 開始請求先コード
                extrInfo_DemandBalanceWork.Ed_ClaimCode = extrInfo_AccRecBalance.Ed_ClaimCode;// 終了請求先コード

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                extrInfo_DemandBalanceWork.OutMoneyDiv  = (int)extrInfo_AccRecBalance.OutMoneyDiv;// 出力金額区分 
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ データ展開処理
		/// <summary>
        /// データ展開処理
		/// </summary>
        /// <param name="extrInfo_AccRecBalance">UI抽出条件クラス</param>
		/// <param name="dmdBalanceDt">展開対象DataTable</param>
        /// <param name="dmdBalanceWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : データを展開する。</br>
        /// <br>Programmer : 矢田 敬吾</br>
	    /// <br>Date       : 2007.11.19</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
		/// </remarks>
        private void DevDmdBalanceData(ExtrInfo_AccRecBalance extrInfo_AccRecBalance, DataTable dmdBalanceDt, ArrayList dmdBalanceWork)
		{
			DataRow dr;
            
           //foreach (RsltInfo_DemandBalanceWork rsltInfo_DemandBalanceWork in dmdBalanceWork)
            foreach(RsltInfo_AccRecBalanceWork rsltInfo_DemandBalanceWork in dmdBalanceWork)
			{
               
                dr = dmdBalanceDt.NewRow();
                                
                // 計上拠点コード
                dr[DCKAU02604EA.Col_AddUpSecCode] = rsltInfo_DemandBalanceWork.AddUpSecCode;

                //// 計上拠点名称
                //if (extrInfo_DmdBalance.IsSelectAllSection)
                //    dr[DCKAU02604EA.Col_AddUpSecName] = "全社";
                //else
                //    dr[DCKAU02604EA.Col_AddUpSecName] = rsltInfo_DemandBalanceWork.AddUpSecName.TrimEnd();

                // 計上拠点名称
                dr[DCKAU02604EA.Col_AddUpSecName] = rsltInfo_DemandBalanceWork.AddUpSecName.TrimEnd();

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
				// 計上拠点名称(明細)
                dr[DCKAU02604EA.Col_AddUpSecName_Detail] = rsltInfo_DemandBalanceWork.AddUpSecName.TrimEnd();
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 請求先コード
                dr[DCKAU02604EA.Col_ClaimCode] = rsltInfo_DemandBalanceWork.ClaimCode;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                // 請求先名称
                dr[DCKAU02604EA.Col_ClaimName] = rsltInfo_DemandBalanceWork.ClaimName;

                // 請求先名称2
                dr[DCKAU02604EA.Col_ClaimName2] = rsltInfo_DemandBalanceWork.ClaimName2;
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 請求先略称
                dr[DCKAU02604EA.Col_ClaimSnm] = rsltInfo_DemandBalanceWork.ClaimSnm;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                // 計上年月日
                dr[DCKAU02604EA.Col_AddUpDate] = TDateTime.DateTimeToString(ExtrInfo_AccRecBalance.ct_DateFomat, rsltInfo_DemandBalanceWork.AddUpDate);
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 計上年月
                dr[DCKAU02604EA.Col_AddUpYearMonth] = TDateTime.DateTimeToString(ExtrInfo_AccRecBalance.ct_MonthFomat, rsltInfo_DemandBalanceWork.AddUpYearMonth);

                // 前回売掛金額
                dr[DCKAU02604EA.Col_LastTimeAccRec] = rsltInfo_DemandBalanceWork.LastTimeAccRec;

                // 今回入金金額
                dr[DCKAU02604EA.Col_ThisTimeDmdNrml] = rsltInfo_DemandBalanceWork.ThisTimeDmdNrml;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                // 今回手数料額（通常入金）
                dr[DCKAU02604EA.Col_ThisTimeFeeDmdNrml] = rsltInfo_DemandBalanceWork.ThisTimeFeeDmdNrml;

                // 今回値引額（通常入金）
                dr[DCKAU02604EA.Col_ThisTimeDisDmdNrml] = rsltInfo_DemandBalanceWork.ThisTimeDisDmdNrml;
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 今回繰越残高(請求計)
                dr[DCKAU02604EA.Col_ThisTimeTtlBlcAcc] = rsltInfo_DemandBalanceWork.ThisTimeTtlBlcAcc;

                // 相殺後今回売上金額
                // --- DEL 2009/02/21 -------------------------------->>>>>
                //// --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                ////dr[DCKAU02604EA.Col_OfsThisTimeSales] = rsltInfo_DemandBalanceWork.OfsThisTimeSales;
                //if (rsltInfo_DemandBalanceWork.ThisSalesPricRgds + rsltInfo_DemandBalanceWork.ThisSalesPricDis >= 0)
                //{
                //    dr[DCKAU02604EA.Col_OfsThisTimeSales] = rsltInfo_DemandBalanceWork.ThisTimeSales -
                //                                            rsltInfo_DemandBalanceWork.ThisSalesPricRgds -
                //                                            rsltInfo_DemandBalanceWork.ThisSalesPricDis;
                //}
                //else
                //{
                //    dr[DCKAU02604EA.Col_OfsThisTimeSales] = rsltInfo_DemandBalanceWork.ThisTimeSales +
                //                                            rsltInfo_DemandBalanceWork.ThisSalesPricRgds +
                //                                            rsltInfo_DemandBalanceWork.ThisSalesPricDis;
                //}
                //// --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
                // --- DEL 2009/02/21 --------------------------------<<<<<
                // --- ADD 2009/02/21 -------------------------------->>>>>
                dr[DCKAU02604EA.Col_OfsThisTimeSales] = rsltInfo_DemandBalanceWork.ThisTimeSales +
                                                                rsltInfo_DemandBalanceWork.ThisSalesPricRgds +
                                                                rsltInfo_DemandBalanceWork.ThisSalesPricDis;
                // --- ADD 2009/02/21 --------------------------------<<<<<

                // 相殺後今回売上消費税
                dr[DCKAU02604EA.Col_OfsThisSalesTax] = rsltInfo_DemandBalanceWork.OfsThisSalesTax;

                // 今回売上金額
                dr[DCKAU02604EA.Col_ThisTimeSales] = rsltInfo_DemandBalanceWork.ThisTimeSales;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                // 今回売上消費税
                dr[DCKAU02604EA.Col_ThisSalesTax] = rsltInfo_DemandBalanceWork.ThisSalesTax;

                // 今回売上返品金額
                dr[DCKAU02604EA.Col_ThisSalesPricRgds] = rsltInfo_DemandBalanceWork.ThisSalesPricRgds;

                // 今回売上返品消費税
                dr[DCKAU02604EA.Col_ThisSalesPrcTaxRgds] = rsltInfo_DemandBalanceWork.ThisSalesPrcTaxRgds;

                // 今回売上値引金額
                dr[DCKAU02604EA.Col_ThisSalesPricDis] = rsltInfo_DemandBalanceWork.ThisSalesPricDis;

                // 今回売上値引消費税
                dr[DCKAU02604EA.Col_ThisSalesPrcTaxDis] = rsltInfo_DemandBalanceWork.ThisSalesPrcTaxDis;

                // 今回支払相殺金額
                dr[DCKAU02604EA.Col_ThisPayOffset] = rsltInfo_DemandBalanceWork.ThisPayOffset;

                // 今回支払相殺消費税
                dr[DCKAU02604EA.Col_ThisPayOffsetTax] = rsltInfo_DemandBalanceWork.ThisPayOffsetTax;

                // 消費税調整額
                dr[DCKAU02604EA.Col_TaxAdjust] = rsltInfo_DemandBalanceWork.TaxAdjust;

                // 残高調整額
                dr[DCKAU02604EA.Col_BalanceAdjust] = rsltInfo_DemandBalanceWork.BalanceAdjust;
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 計算後当月売掛金額
                dr[DCKAU02604EA.Col_AfCalTMonthAccRec] = rsltInfo_DemandBalanceWork.AfCalTMonthAccRec;

                // 売上伝票枚数
                dr[DCKAU02604EA.Col_SalesSlipCount] = rsltInfo_DemandBalanceWork.SalesSlipCount;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                // 未決済金額(自振)
                dr[DCKAU02604EA.Col_NonStmntAppearance] = rsltInfo_DemandBalanceWork.NonStmntAppearance;

                // 未決済金額(廻し)
                dr[DCKAU02604EA.Col_NonStmntlsdone] = rsltInfo_DemandBalanceWork.NonStmntIsdone;

                // 決済金額(自振)
                dr[DCKAU02604EA.Col_StmntAppearance] = rsltInfo_DemandBalanceWork.StmntAppearance;

                // 決済金額(廻し)
                dr[DCKAU02604EA.Col_Stmntlsdone] = rsltInfo_DemandBalanceWork.StmntIsdone;
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 回収条件
                dr[DCKAU02604EA.Col_CollectCond] = GetCondName(rsltInfo_DemandBalanceWork.CollectCond);

                // 請求締日
                dr[DCKAU02604EA.Col_TotalDay] = rsltInfo_DemandBalanceWork.TotalDay;
                
                // 回収月区分名称
                dr[DCKAU02604EA.Col_CollectMoneyName] = rsltInfo_DemandBalanceWork.CollectMoneyName;
                
                // 回収日
                dr[DCKAU02604EA.Col_CollectMoneyDay] = rsltInfo_DemandBalanceWork.CollectMoneyDay;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                // 集金担当従業員コード
                dr[DCKAU02604EA.Col_BillCollecterCd] = rsltInfo_DemandBalanceWork.BillCollecterCd;
                   --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                // 集金担当従業員名称
                dr[DCKAU02604EA.Col_BillCollecterNm] = rsltInfo_DemandBalanceWork.BillCollecterNm;

                // 返品・値引
                //dr[DCKAU02604EA.Col_RgdsDisT] = rsltInfo_DemandBalanceWork.ThisSalesPricRgds + rsltInfo_DemandBalanceWork.ThisSalesPricDis; // DEL 2009/02/21
                dr[DCKAU02604EA.Col_RgdsDisT] = (rsltInfo_DemandBalanceWork.ThisSalesPricRgds + rsltInfo_DemandBalanceWork.ThisSalesPricDis) * -1; // ADD 2009/02/21

                // 税込売上額
                // --- DEL 2009/02/24 -------------------------------->>>>>
                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                ////dr[DCKAU02604EA.Col_TimeSalesTax] = rsltInfo_DemandBalanceWork.OfsThisTimeSales + rsltInfo_DemandBalanceWork.OfsThisSalesTax;
                //if (rsltInfo_DemandBalanceWork.ThisSalesPricRgds + rsltInfo_DemandBalanceWork.ThisSalesPricDis >= 0)
                //{
                //    dr[DCKAU02604EA.Col_TimeSalesTax] = rsltInfo_DemandBalanceWork.ThisTimeSales -
                //                                        rsltInfo_DemandBalanceWork.ThisSalesPricRgds -
                //                                        rsltInfo_DemandBalanceWork.ThisSalesPricDis +
                //                                        rsltInfo_DemandBalanceWork.OfsThisSalesTax;
                //}
                //else
                //{
                //    dr[DCKAU02604EA.Col_TimeSalesTax] = rsltInfo_DemandBalanceWork.ThisTimeSales +
                //                                        rsltInfo_DemandBalanceWork.ThisSalesPricRgds +
                //                                        rsltInfo_DemandBalanceWork.ThisSalesPricDis +
                //                                        rsltInfo_DemandBalanceWork.OfsThisSalesTax;
                //}
                //// --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
                // --- DEL 2009/02/24 --------------------------------<<<<<
                // --- ADD 2009/02/24 -------------------------------->>>>>
                dr[DCKAU02604EA.Col_TimeSalesTax] = rsltInfo_DemandBalanceWork.ThisTimeSales +
                                                            rsltInfo_DemandBalanceWork.ThisSalesPricRgds +
                                                            rsltInfo_DemandBalanceWork.ThisSalesPricDis +
                                                            rsltInfo_DemandBalanceWork.OfsThisSalesTax;
                // --- ADD 2009/02/24 --------------------------------<<<<<

				// TableにAdd
                //dmdBalanceDt.Rows.Add(dr); // DEL 2014/02/26 田建委 Redmine#42188
                //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
                if (extrInfo_AccRecBalance.PrintMoneyDivCd == 0 ||
                    (extrInfo_AccRecBalance.PrintMoneyDivCd == 1 && !IsMoneyAllZero(dr)))
                {
				dmdBalanceDt.Rows.Add( dr );
                }
                //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<
			}

		}
		#endregion

        //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
        /// <summary>
        /// 明細行の全ての金額が０かどうかのチェック
        /// </summary>
        /// <param name="dr">明細行データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 明細行の全ての金額が０かどうかのチェックを行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date	   : 2014/02/26</br>
        /// </remarks>
        private bool IsMoneyAllZero(DataRow dr)
        {
            bool isAllZero = true;

            if ((Int64)dr[DCKAU02604EA.Col_LastTimeAccRec] != 0 ||  // 前回売掛金額
                (Int64)dr[DCKAU02604EA.Col_ThisTimeDmdNrml] != 0 ||  // 今回入金金額
                (Int64)dr[DCKAU02604EA.Col_ThisTimeTtlBlcAcc] != 0 ||  // 今回繰越残高(請求計)
                (Int64)dr[DCKAU02604EA.Col_OfsThisTimeSales] != 0 ||  // 相殺後今回売上金額
                (Int64)dr[DCKAU02604EA.Col_OfsThisSalesTax] != 0 ||  // 相殺後今回売上消費税
                (Int64)dr[DCKAU02604EA.Col_ThisTimeSales] != 0 ||  // 今回売上金額
                (Int64)dr[DCKAU02604EA.Col_AfCalTMonthAccRec] != 0 ||  // 計算後当月売掛金額
                (Int32)dr[DCKAU02604EA.Col_SalesSlipCount] != 0 ||  // 売上伝票枚数
                (Int64)dr[DCKAU02604EA.Col_RgdsDisT] != 0 ||  // 返品・値引
                (Int64)dr[DCKAU02604EA.Col_TimeSalesTax] != 0     // 税込売上額
                )
            {
                isAllZero = false;
                return isAllZero;
			}

            return isAllZero;
		}
        //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<

		#endregion ◆ データ展開処理

		#region ◆ 帳票設定データ取得

        #region ◆ 固定項目名称設定
        #region ◎ 回収区分名称取得
        /// <summary>
        /// 回収条件名称取得
        /// </summary>
        /// <param name="ｃollectCond">回収コード</param>
        /// <remarks>
        /// <br>Note       : 回収区分名称を取得する。</br>
        /// <br>Programmer : 矢田 敬吾</br>
        /// <br>Date       : 2007.11.19</br>
        /// </remarks>
        private string GetCondName(int ｃollectCond)
        {
            string pCName = "";
            // 名称をセット
            switch (ｃollectCond)
            {
                case 10:
                    pCName = "現金";
                    break;
                case 20:
                    pCName = "振込";
                    break;
                case 30:
                    pCName = "小切手";
                    break;
                case 40:
                    pCName = "手形";
                    break;
                case 50:
                    pCName = "手数料";
                    break;
                case 60:
                    pCName = "相殺";
                    break;
                case 70:
                    pCName = "値引";
                    break;
                case 80:
                    pCName = "その他";
                    break;
            }
            return (pCName);
        }
        #endregion

        #endregion ◆ 固定項目取得

        #region ◎ 帳票出力設定取得処理
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
	    /// <br>Programmer : 矢田 敬吾</br>
	    /// <br>Date       : 2007.11.19</br>
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
