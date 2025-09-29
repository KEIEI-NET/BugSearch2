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
    /// 支払残高元帳アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払残高元帳で使用するデータを取得する。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br>Update Note: 2008/12/10 30414 忍 幸史 Partsman用に変更</br>    
    /// <br>Update Note: 2014/02/26 田建委</br>
    /// <br>           : Redmine#42188 出力金額区分追加</br>
    /// </remarks>
	public class PaymentBalanceAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 支払残高元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払残高元帳アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.03</br>
		/// </remarks>
		public PaymentBalanceAcs()
		{
            this._iPaymentBalanceLedgerDB = (IPaymentBalanceLedgerDB)MediationPaymentBalanceLedgerDB.GetPaymentBalanceLedgerDB();
		}

		/// <summary>
        /// 支払残高元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払残高元帳アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.03</br>
		/// </remarks>
		static PaymentBalanceAcs()
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
        IPaymentBalanceLedgerDB _iPaymentBalanceLedgerDB;  

		private DataSet _payBalanceDs;				    // 残高元帳データセット

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
        /// 残高元帳データセット(読み取り専用)
		/// </summary>
		public DataSet PayBalanceDs
		{
			get{ return this._payBalanceDs; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
        #region ◎ 残高元帳データ取得
        /// <summary>
		/// データ取得
		/// </summary>
        /// <param name="extrInfo_PaymentBalance">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する残高元帳データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.03</br>
		/// </remarks>
        public int SearchPaymentBalance(ExtrInfo_PaymentBalance extrInfo_PaymentBalance, out string errMsg)
		{
            return this.SearchPaymentBalanceProc(extrInfo_PaymentBalance, out errMsg);
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
        /// <param name="extrInfo_PaymentBalance"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.03</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
		/// </remarks>
        private int SearchPaymentBalanceProc(ExtrInfo_PaymentBalance extrInfo_PaymentBalance, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAK02564EA.CreateDataTablePaymentBalanceMain(ref this._payBalanceDs);
                ExtrInfo_PaymentBalanceWork extrInfo_PaymentBalanceWork = new ExtrInfo_PaymentBalanceWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevPaymentBalance(extrInfo_PaymentBalance, out extrInfo_PaymentBalanceWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retPaymentBalanceList = null;
                status = this._iPaymentBalanceLedgerDB.SearchPaymentBalanceLedger( out retPaymentBalanceList, extrInfo_PaymentBalanceWork );
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
                        DevPaymentBalanceData(extrInfo_PaymentBalance, this._payBalanceDs.Tables[DCKAK02564EA.Col_Tbl_PaymentBalance], (ArrayList)retPaymentBalanceList);
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL 2014/02/26 田建委 Redmine#42188
                        //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
                        if (this._payBalanceDs.Tables[DCKAK02564EA.Col_Tbl_PaymentBalance].DefaultView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "支払残高元帳データの取得に失敗しました。";
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
		/// <param name="extrInfo_PaymentBalance">UI抽出条件クラス</param>
		/// <param name="extrInfo_PaymentBalanceWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevPaymentBalance(ExtrInfo_PaymentBalance extrInfo_PaymentBalance, out ExtrInfo_PaymentBalanceWork extrInfo_PaymentBalanceWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            extrInfo_PaymentBalanceWork = new ExtrInfo_PaymentBalanceWork();

			try
			{
				extrInfo_PaymentBalanceWork.EnterpriseCode = extrInfo_PaymentBalance.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (extrInfo_PaymentBalance.PaymentAddupSecCodeList.Length != 0)
				{
					if ( extrInfo_PaymentBalance.IsSelectAllSection )
					{
						// 全社の時
                        extrInfo_PaymentBalanceWork.PaymentAddupSecCodeList = null;
					}
					else
					{
                        extrInfo_PaymentBalanceWork.PaymentAddupSecCodeList = extrInfo_PaymentBalance.PaymentAddupSecCodeList;
					}
				}
				else
				{
                    extrInfo_PaymentBalanceWork.PaymentAddupSecCodeList = null;
				}

                extrInfo_PaymentBalanceWork.St_AddUpYearMonth = extrInfo_PaymentBalance.St_AddUpYearMonth;         // 開始対象年月
                extrInfo_PaymentBalanceWork.Ed_AddUpYearMonth = extrInfo_PaymentBalance.Ed_AddUpYearMonth;         // 終了対象年月
                extrInfo_PaymentBalanceWork.St_PayeeCode = extrInfo_PaymentBalance.St_PayeeCode;		           // 開始支払先コード
                extrInfo_PaymentBalanceWork.Ed_PayeeCode = extrInfo_PaymentBalance.Ed_PayeeCode;		           // 終了支払先コード
                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                extrInfo_PaymentBalanceWork.OutMoneyDiv = (int)extrInfo_PaymentBalance.OutMoneyDiv;                // 出力金額区分 
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
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
		/// <param name="extrInfo_PaymentBalance">UI抽出条件クラス</param>
		/// <param name="paymentBalanceDt">展開対象DataTable</param>
        /// <param name="paymentBalanceWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.03</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
		/// </remarks>
        private void DevPaymentBalanceData(ExtrInfo_PaymentBalance extrInfo_PaymentBalance, DataTable paymentBalanceDt, ArrayList paymentBalanceWork)
		{
			DataRow dr;
            foreach (RsltInfo_PaymentBalanceWork rsltInfo_PaymentBalanceWork in paymentBalanceWork)
			{
                dr = paymentBalanceDt.NewRow();
			    
                // 計上拠点コード
                dr[DCKAK02564EA.Col_AddUpSecCode] = rsltInfo_PaymentBalanceWork.AddUpSecCode;
				// 計上拠点名称
                //if ( extrInfo_PaymentBalance.IsSelectAllSection)
                //    dr[DCKAK02564EA.Col_AddUpSecName] = "全社";
                //else
                dr[DCKAK02564EA.Col_AddUpSecName] = rsltInfo_PaymentBalanceWork.AddUpSecName.TrimEnd();

                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
				// 計上拠点名称(明細)
                dr[DCKAK02564EA.Col_AddUpSecName_Detail] = rsltInfo_PaymentBalanceWork.AddUpSecName.TrimEnd();
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
                
                // 支払先コード
                dr[DCKAK02564EA.Col_PayeeCode] = rsltInfo_PaymentBalanceWork.PayeeCode;
                
                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                // 支払先名称
                dr[DCKAK02564EA.Col_PayeeName] = rsltInfo_PaymentBalanceWork.PayeeName;
                // 支払先名称2
                dr[DCKAK02564EA.Col_PayeeName2] = rsltInfo_PaymentBalanceWork.PayeeName2;
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                // 支払先略称
                dr[DCKAK02564EA.Col_PayeeSnm] = rsltInfo_PaymentBalanceWork.PayeeSnm;
                // 計上日
                dr[DCKAK02564EA.Col_AddUpDate] = TDateTime.DateTimeToString(ExtrInfo_PaymentBalance.ct_DateFomat, rsltInfo_PaymentBalanceWork.AddUpDate);
                // 前回支払金額
                // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //dr[DCKAK02564EA.Col_LastTimePayment] = rsltInfo_PaymentBalanceWork.LastTimePayment;
                dr[DCKAK02564EA.Col_LastTimePayment] = rsltInfo_PaymentBalanceWork.StockTtl3TmBfBlPay +
                                                       rsltInfo_PaymentBalanceWork.StockTtl2TmBfBlPay +
                                                       rsltInfo_PaymentBalanceWork.LastTimePayment;
                // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                
                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                // 今回手数料額(通常支払)
                dr[DCKAK02564EA.Col_ThisTimeFeePayNrml] = rsltInfo_PaymentBalanceWork.ThisTimeFeePayNrml;
                // 今回値引額(通常支払)
                dr[DCKAK02564EA.Col_ThisTimeDisPayNrml] = rsltInfo_PaymentBalanceWork.ThisTimeDisPayNrml;
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                // 今回支払金額(通常支払)
                dr[DCKAK02564EA.Col_ThisTimePayNrml] = rsltInfo_PaymentBalanceWork.ThisTimePayNrml;
                // 今回繰越残高
                dr[DCKAK02564EA.Col_ThisTimeTtlBlcPay] = rsltInfo_PaymentBalanceWork.ThisTimeTtlBlcPay;
                // 相殺後今回仕入金額
                // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //dr[DCKAK02564EA.Col_OfsThisTimeStock] = rsltInfo_PaymentBalanceWork.OfsThisTimeStock;
                dr[DCKAK02564EA.Col_OfsThisTimeStock] = rsltInfo_PaymentBalanceWork.ThisTimeStockPrice +
                                                        rsltInfo_PaymentBalanceWork.ThisStckPricRgds +
                                                        rsltInfo_PaymentBalanceWork.ThisStckPricDis;
                // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                // 相殺後今回仕入消費税
                dr[DCKAK02564EA.Col_OfsThisStockTax] = rsltInfo_PaymentBalanceWork.OfsThisStockTax;
                // 今回仕入金額
                dr[DCKAK02564EA.Col_ThisTimeStockPrice] = rsltInfo_PaymentBalanceWork.ThisTimeStockPrice;
                
                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                // 今回仕入消費税
                dr[DCKAK02564EA.Col_ThisStcPrcTax] = rsltInfo_PaymentBalanceWork.ThisStcPrcTax;
                // 今回返品金額
                dr[DCKAK02564EA.Col_ThisStckPricRgds] = rsltInfo_PaymentBalanceWork.ThisStckPricRgds;
                // 今回返品消費税
                dr[DCKAK02564EA.Col_ThisStcPrcTaxRgds] = rsltInfo_PaymentBalanceWork.ThisStcPrcTaxRgds;
                // 今回値引金額
                dr[DCKAK02564EA.Col_ThisStckPricDis] = rsltInfo_PaymentBalanceWork.ThisStckPricDis;
                // 今回値引消費税
                dr[DCKAK02564EA.Col_ThisStcPrcTaxDis] = rsltInfo_PaymentBalanceWork.ThisStcPrcTaxDis;
                // 今回受取金額
                dr[DCKAK02564EA.Col_ThisRecvOffset] = rsltInfo_PaymentBalanceWork.ThisRecvOffset;
                // 今回受取相殺消費税
                dr[DCKAK02564EA.Col_ThisRecvOffsetTax] = rsltInfo_PaymentBalanceWork.ThisRecvOffsetTax;
                // 消費税調整額
                dr[DCKAK02564EA.Col_TaxAdjust] = rsltInfo_PaymentBalanceWork.TaxAdjust;
                // 残高調整額
                dr[DCKAK02564EA.Col_BalanceAdjust] = rsltInfo_PaymentBalanceWork.BalanceAdjust;
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                // 仕入合計残高
                dr[DCKAK02564EA.Col_StockTotalPayBalance] = rsltInfo_PaymentBalanceWork.StockTotalPayBalance;
                // 仕入伝票枚数
                dr[DCKAK02564EA.Col_StockSlipCount] = rsltInfo_PaymentBalanceWork.StockSlipCount;
                
                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                // 支払予定日
                dr[DCKAK02564EA.Col_PaymentSchedule] = TDateTime.DateTimeToString(ExtrInfo_PaymentBalance.ct_DateFomat, rsltInfo_PaymentBalanceWork.PaymentSchedule);
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                // 支払条件
                dr[DCKAK02564EA.Col_PaymentCond] = GetPaymentCondName(rsltInfo_PaymentBalanceWork.PaymentCond);
                // 2009.02.09 30413 犬飼 返品・値引きの符号を反転 >>>>>>START
                // 返品・値引
                //dr[DCKAK02564EA.Col_RgdsDisT] = rsltInfo_PaymentBalanceWork.ThisStckPricRgds + rsltInfo_PaymentBalanceWork.ThisStckPricDis;
                dr[DCKAK02564EA.Col_RgdsDisT] = -(rsltInfo_PaymentBalanceWork.ThisStckPricRgds + rsltInfo_PaymentBalanceWork.ThisStckPricDis);
                // 2009.02.09 30413 犬飼 返品・値引きの符号を反転 <<<<<<END
                // 税込仕入額
                // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //dr[DCKAK02564EA.Col_ThisNetStckTax] = rsltInfo_PaymentBalanceWork.OfsThisTimeStock + rsltInfo_PaymentBalanceWork.OfsThisStockTax;
                dr[DCKAK02564EA.Col_ThisNetStckTax] = rsltInfo_PaymentBalanceWork.ThisTimeStockPrice +
                                                        rsltInfo_PaymentBalanceWork.ThisStckPricRgds +
                                                        rsltInfo_PaymentBalanceWork.ThisStckPricDis +
                                                      rsltInfo_PaymentBalanceWork.OfsThisStockTax;
                // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                // 締日
                dr[DCKAK02564EA.Col_PaymentTotalDay] = rsltInfo_PaymentBalanceWork.PaymentTotalDay;
                // 支払月
                dr[DCKAK02564EA.Col_PaymentMonthName] = rsltInfo_PaymentBalanceWork.PaymentMonthName;
                // 支払日
                dr[DCKAK02564EA.Col_PaymentDay] = rsltInfo_PaymentBalanceWork.PaymentDay;

				// TableにAdd
                //paymentBalanceDt.Rows.Add( dr ); // ADD 2014/02/26 田建委 Redmine#42188
                //----- ADD 2014/02/26 田建委 Redmine#42188 ---------->>>>>
                if (extrInfo_PaymentBalance.PrintMoneyDivCd == 0 ||
                    (extrInfo_PaymentBalance.PrintMoneyDivCd == 1 && !IsMoneyAllZero(dr)))
                {
				paymentBalanceDt.Rows.Add( dr );
			}
                //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<
			}
		}
		#endregion

		#endregion ◆ データ展開処理

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

            if ((Int64)dr[DCKAK02564EA.Col_LastTimePayment] != 0 ||  // 前回支払金額
                (Int64)dr[DCKAK02564EA.Col_ThisTimePayNrml] != 0 ||  // 今回支払金額(通常支払)
                (Int64)dr[DCKAK02564EA.Col_ThisTimeTtlBlcPay] != 0 ||  // 今回繰越残高
                (Int64)dr[DCKAK02564EA.Col_OfsThisTimeStock] != 0 ||  // 相殺後今回仕入金額
                (Int64)dr[DCKAK02564EA.Col_OfsThisStockTax] != 0 ||  // 相殺後今回仕入消費税
                (Int64)dr[DCKAK02564EA.Col_ThisTimeStockPrice] != 0 ||  // 今回仕入金額
                (Int64)dr[DCKAK02564EA.Col_StockTotalPayBalance] != 0 ||  // 仕入合計残高
                (Int32)dr[DCKAK02564EA.Col_StockSlipCount] != 0 ||  // 仕入伝票枚数
                (Int64)dr[DCKAK02564EA.Col_RgdsDisT] != 0 ||  // 返品・値引
                (Int64)dr[DCKAK02564EA.Col_ThisNetStckTax] != 0     // 税込仕入額
                )
            {
                isAllZero = false;
                return isAllZero;
            }

            return isAllZero;
        }
        //----- ADD 2014/02/26 田建委 Redmine#42188 ----------<<<<<

		#region ◆ 帳票設定データ取得

        #region ◆ 固定項目名称設定
        #region ◎ 支払区分名称取得
        /// <summary>
        /// 支払区分名称取得
        /// </summary>
        /// <param name="paymentCondCd">支払区分コード</param>
        /// <remarks>
        /// <br>Note       : 支払区分名称を取得する。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.02</br>
        /// </remarks>
        private string GetPaymentCondName(int paymentCondCd)
        {
            string pCName = "";

            // 名称をセット
            switch (paymentCondCd)
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
                default:
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
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.03</br>
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
