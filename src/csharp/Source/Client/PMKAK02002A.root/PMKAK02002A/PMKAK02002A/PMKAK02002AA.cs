//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
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
    /// 支払一覧表（総括）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払一覧表（総括）で使用するデータを取得する。</br>
    /// <br>Programmer : FSI東 隆史</br>
    /// <br>Date       : 2012/09/04</br>
    /// </remarks>
	public class SumSuplierPayMainAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 支払一覧表（総括）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払一覧表（総括）アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : FSI東 隆史</br>
	    /// <br>Date       : 2012/09/04</br>
		/// </remarks>
		public SumSuplierPayMainAcs()
		{
            this._iSumPaymentTableDB = (ISumPaymentTableDB)MediationSumPaymentTableDB.GetSumPaymentTableDB();
		}

		/// <summary>
		/// 支払一覧表（総括）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払一覧表（総括）アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : FSI東 隆史</br>
	    /// <br>Date       : 2012/09/04</br>
		/// </remarks>
		static SumSuplierPayMainAcs()
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

            // 請求初期値設定アクセスクラスインスタンス化
            mBillPrtStAcs = new BillPrtStAcs();
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
        ISumPaymentTableDB _iSumPaymentTableDB;  

		private DataSet _suppayDs;				        // 仕入先支払データセット

        // 仕入合計残高のキャッシュ
        private Dictionary<string, long> stockTotalPayBalanceDic;

        /// <summary>請求初期値設定アクセスクラス</summary>
        private static BillPrtStAcs mBillPrtStAcs = null;
        /// <summary>請求初期値設定</summary>
        private static BillPrtSt _billPrtSt = null;
        #endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 仕入支払データセット(読み取り専用)
		/// </summary>
		public DataSet SuplierPayDs
		{
			get{ return this._suppayDs; }
		}

        /// <summary>請求印刷設定</summary>
        public BillPrtSt BillPrtStData
        {
            get { return _billPrtSt; }
        }

		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 支払データ取得
		/// <summary>
		/// 仕入先支払データ取得
		/// </summary>
        /// <param name="suplierpaymainCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する支払データを取得する。</br>
	    /// <br>Programmer : FSI東 隆史</br>
	    /// <br>Date       : 2012/09/04</br>
		/// </remarks>
        public int SearchSuplierPayMain(SumSuplierPayMainCndtn suplierpaymainCndtn, out string errMsg)
		{
            return this.SearchSuplierPayMainProc(suplierpaymainCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 仕入先支払データ取得
		/// <summary>
		/// 仕入先支払データ取得
		/// </summary>
        /// <param name="sumSuplierPayMainCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する支払データを取得する。</br>
	    /// <br>Programmer : FSI東 隆史</br>
	    /// <br>Date       : 2012/09/04</br>
		/// </remarks>
        private int SearchSuplierPayMainProc(SumSuplierPayMainCndtn sumSuplierPayMainCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMKAK02005EA.CreateDataTableSuplierPayMain(ref this._suppayDs);
                ExtrInfo_SumPaymentTotalWork extrInfo_SumPaymentTotalWork = new ExtrInfo_SumPaymentTotalWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevSumSuplierPayMainCndtn(sumSuplierPayMainCndtn, out extrInfo_SumPaymentTotalWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retSuplierPayMainList = null;
                status = this._iSumPaymentTableDB.SearchPaymentTable( out retSuplierPayMainList, extrInfo_SumPaymentTotalWork );
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        stockTotalPayBalanceDic = new Dictionary<string, long>();
                        
						// データ展開処理
                        DevSuplierPayMainData(sumSuplierPayMainCndtn, this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain], (ArrayList)retSuplierPayMainList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            // フィルター用の仕入合計残高を設定
                            SetStockTotalPayBalanceFilter();

                            // 出力金額区分のフィルター設定
                            this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter = this.SelectOutputMoneyDivFilter(sumSuplierPayMainCndtn);

                            if (this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].DefaultView.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            }
                            else
                            {
                                if (sumSuplierPayMainCndtn.SumPayeeDetail == 0)
                                {
                                    // 総括支払先内訳が"印字する"
                                    string filter = this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter;
                                    this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter = this.SelectTotalRecordOnlyFilter(filter);
                                }
                            }
                        }

                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "仕入先支払データの取得に失敗しました。";
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
		/// <param name="sumSuplierPayMainCndtn">UI抽出条件クラス</param>
		/// <param name="extrInfo_SumPaymentTotalWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevSumSuplierPayMainCndtn(SumSuplierPayMainCndtn sumSuplierPayMainCndtn, out ExtrInfo_SumPaymentTotalWork extrInfo_SumPaymentTotalWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            extrInfo_SumPaymentTotalWork = new ExtrInfo_SumPaymentTotalWork();

			try
			{
				extrInfo_SumPaymentTotalWork.EnterpriseCode = sumSuplierPayMainCndtn.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (sumSuplierPayMainCndtn.PaymentAddupSecCodeList.Length != 0)
				{
					if ( sumSuplierPayMainCndtn.IsSelectAllSection )
					{
						// 全社の時
                        extrInfo_SumPaymentTotalWork.PaymentAddupSecCodeList = null;
					}
					else
					{
                        extrInfo_SumPaymentTotalWork.PaymentAddupSecCodeList = sumSuplierPayMainCndtn.PaymentAddupSecCodeList;
					}
				}
				else
				{
                    extrInfo_SumPaymentTotalWork.PaymentAddupSecCodeList = null;
				}

                extrInfo_SumPaymentTotalWork.CAddUpUpdExecDate = sumSuplierPayMainCndtn.CAddUpUpdExecDate;        // 締日
                
                extrInfo_SumPaymentTotalWork.St_PayeeCode = sumSuplierPayMainCndtn.St_PayeeCode;                  // 開始支払先コード
                extrInfo_SumPaymentTotalWork.Ed_PayeeCode = sumSuplierPayMainCndtn.Ed_PayeeCode;                  // 終了支払先コード
   			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 仕入先支払データ展開処理
		/// <summary>
        /// 仕入先支払データ展開処理
		/// </summary>
		/// <param name="sumSuplierPayMainCndtn">UI抽出条件クラス</param>
		/// <param name="suplierPayMainDt">展開対象DataTable</param>
		/// <param name="suplierPayMainWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 仕入先支払データを展開する。</br>
	    /// <br>Programmer : FSI東 隆史</br>
	    /// <br>Date       : 2012/09/04</br>
		/// </remarks>
        private void DevSuplierPayMainData(SumSuplierPayMainCndtn sumSuplierPayMainCndtn, DataTable suplierPayMainDt, ArrayList suplierPayMainWork)
		{
			DataRow dr;
            foreach (RsltInfo_SumPaymentTotalWork spaymainResWork in suplierPayMainWork)
			{
                if (sumSuplierPayMainCndtn.SumPayeeDetail == 0)
                {
                    // 総括支払先内訳が"印字する"

                    // 仕入先が0以外かつ実績拠点が'00'以外のとき、すなわち、集計レコード以外は印刷対象外とする
                    if ((spaymainResWork.SupplierCd != 0) &&
                        (spaymainResWork.ResultsSectCd.TrimEnd() != "00"))
                    {
                        // 印刷対象データでは無い
                        continue;
                    }
                }

                dr = suplierPayMainDt.NewRow();

                // 総括計上拠点コード
                dr[PMKAK02005EA.Col_SumAddUpSecCode] = spaymainResWork.SumAddUpSecCode;
                // 総括計上拠点名称
                dr[PMKAK02005EA.Col_SumAddUpSecName] = spaymainResWork.SumAddUpSecName.TrimEnd();
                // 計上拠点コード
                dr[PMKAK02005EA.Col_AddUpSecCode] = spaymainResWork.AddUpSecCode;
                // 計上拠点名称
                dr[PMKAK02005EA.Col_AddUpSecName] = spaymainResWork.AddUpSecName.TrimEnd();
                // 計上拠点名称(明細)
                dr[PMKAK02005EA.Col_AddUpSecName_Detail] = spaymainResWork.AddUpSecName.TrimEnd();
                // 実績拠点コード
                dr[PMKAK02005EA.Col_ResultsSectCd] = spaymainResWork.ResultsSectCd;
                // 総括支払先コード
                dr[PMKAK02005EA.Col_SumPayeeCode] = spaymainResWork.SumPayeeCode;
                // 総括支払先略称
                dr[PMKAK02005EA.Col_SumPayeeSnm] = spaymainResWork.SumPayeeSnm;
                // 支払先コード
                dr[PMKAK02005EA.Col_PayeeCode] = spaymainResWork.PayeeCode;
                // 支払先名称
                dr[PMKAK02005EA.Col_PayeeName] = spaymainResWork.PayeeName;
                // 支払先名称2
                dr[PMKAK02005EA.Col_PayeeName2] = spaymainResWork.PayeeName2;
                // 支払先略称
                dr[PMKAK02005EA.Col_PayeeSnm] = spaymainResWork.PayeeSnm;
                // 仕入先コード
                dr[PMKAK02005EA.Col_SupplierCd] = spaymainResWork.SupplierCd;
                // 仕入先名1
                dr[PMKAK02005EA.Col_SupplierNm1] = spaymainResWork.SupplierNm1;
                // 仕入先名2
                dr[PMKAK02005EA.Col_SupplierNm2] = spaymainResWork.SupplierNm2;
                // 仕入先略称
                dr[PMKAK02005EA.Col_SupplierSnm] = spaymainResWork.SupplierSnm;
                // 計上年月日(表示用)
                dr[PMKAK02005EA.Col_AddUpDate] = TDateTime.DateTimeToString(SumSuplierPayMainCndtn.ct_DateFomat, spaymainResWork.AddUpDate);
                // 計上年月日(ソート用)
                dr[PMKAK02005EA.Col_Sort_AddUpDate] = TDateTime.DateTimeToLongDate(spaymainResWork.AddUpDate);
                // 計上年月(表示用)
                dr[PMKAK02005EA.Col_AddUpYearMonth] = TDateTime.DateTimeToString(SumSuplierPayMainCndtn.ct_DateFomat, spaymainResWork.AddUpYearMonth);
                // 計上年月(ソート用)
                dr[PMKAK02005EA.Col_Sort_AddUpYearMonth] = TDateTime.DateTimeToLongDate(spaymainResWork.AddUpYearMonth);
                // 前回支払金額
                dr[PMKAK02005EA.Col_LastTimePayment] = spaymainResWork.LastTimePayment;
                // 仕入2回前残高（支払計）
                dr[PMKAK02005EA.Col_StockTtl2TmBfBlPay] = spaymainResWork.StockTtl2TmBfBlPay;
                // 仕入3回前残高（支払計）
                dr[PMKAK02005EA.Col_StockTtl3TmBfBlPay] = spaymainResWork.StockTtl3TmBfBlPay;
                // 今回支払金額(通常支払)
                dr[PMKAK02005EA.Col_ThisTimePayNrml] = spaymainResWork.ThisTimePayNrml;
                // 今回繰越残高
                dr[PMKAK02005EA.Col_ThisTimeTtlBlcPay] = spaymainResWork.ThisTimeTtlBlcPay;
                // 相殺後今回仕入金額
                dr[PMKAK02005EA.Col_OfsThisTimeStock] = spaymainResWork.OfsThisTimeStock;
                // 相殺後今回仕入消費税
                dr[PMKAK02005EA.Col_OfsThisStockTax] = spaymainResWork.OfsThisStockTax;
                // 今回仕入金額
                dr[PMKAK02005EA.Col_ThisTimeStockPrice] = spaymainResWork.ThisTimeStockPrice;
                // 今回返品金額
                dr[PMKAK02005EA.Col_ThisStckPricRgds] = spaymainResWork.ThisStckPricRgds;
                // 今回値引金額
                dr[PMKAK02005EA.Col_ThisStckPricDis] = spaymainResWork.ThisStckPricDis;
                // 仕入合計残高
                dr[PMKAK02005EA.Col_StockTotalPayBalance] = spaymainResWork.StockTotalPayBalance;

                // 仕入合計残高をキャッシュ登録
                string key = spaymainResWork.AddUpSecCode.TrimEnd() + "-" + spaymainResWork.PayeeCode.ToString("d06");
                if (spaymainResWork.SupplierCd == 0)
                {
                    // 集計レコード
                    if (!stockTotalPayBalanceDic.ContainsKey(key))
                    {
                        stockTotalPayBalanceDic.Add(key, spaymainResWork.StockTotalPayBalance);
                    }
                }

                // 仕入伝票枚数
                dr[PMKAK02005EA.Col_StockSlipCount] = spaymainResWork.StockSlipCount;
                // 今回手数料額（通常支払）
                dr[PMKAK02005EA.Col_ThisTimeFeePayNrml] = spaymainResWork.ThisTimeFeePayNrml;
                // 今回値引額（通常支払）
                dr[PMKAK02005EA.Col_ThisTimeDisPayNrml] = spaymainResWork.ThisTimeDisPayNrml;
                // 支払月区分名称
                dr[PMKAK02005EA.Col_PaymentMonthName] = spaymainResWork.PaymentMonthName;
                // 支払日
                // 請求書末日印字区分 = 1(28～31日は末日と印字) で28日以降の場合
                if (spaymainResWork.PaymentDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                {
                    dr[PMKAK02005EA.Col_PaymentDay] = "末";
                }
                else
                {
                    dr[PMKAK02005EA.Col_PaymentDay] = spaymainResWork.PaymentDay.ToString();
                }

                // 計算金額(印字用)
                // 支払残高
                dr[PMKAK02005EA.Col_PaymentBalance] = spaymainResWork.LastTimePayment
                                                    + spaymainResWork.StockTtl2TmBfBlPay
                                                    + spaymainResWork.StockTtl3TmBfBlPay;

                long retGoodsDiscount = spaymainResWork.ThisStckPricRgds + spaymainResWork.ThisStckPricDis;
                // 返品値引
                dr[PMKAK02005EA.Col_RetGoodsDiscount] = -retGoodsDiscount;

                long pureCost = spaymainResWork.OfsThisTimeStock;
                // 純仕入額
                dr[PMKAK02005EA.Col_PureCost] = pureCost;

                // 今回合計(純仕入額+相殺後今回仕入消費税)
                dr[PMKAK02005EA.Col_ThisTotal] = pureCost + spaymainResWork.OfsThisStockTax;
                
                // 現金(金種区分)
                dr[PMKAK02005EA.Col_CashPayment] = 0;
                // 振込(金種区分)
                dr[PMKAK02005EA.Col_TrfrPayment] = 0;
                // 小切手(金種区分)
                dr[PMKAK02005EA.Col_CheckPayment] = 0;
                // 手形(金種区分)
                dr[PMKAK02005EA.Col_DraftPayment] = 0;
                // 相殺(金種区分)
                dr[PMKAK02005EA.Col_OffsetPayment] = 0;
                // 口座振替(金種区分)
                dr[PMKAK02005EA.Col_FundTransferPayment] = 0;
                // その他
                dr[PMKAK02005EA.Col_OthsPayment] = 0;

                // 金種コード
                if (spaymainResWork.MoneyKindList != null)
                {
                    foreach (RsltInfo_SumAccPayTotalWork work in spaymainResWork.MoneyKindList)
                    {
                        if (work.MoneyKindDiv == 101)
                        {
                            // 現金(金種区分)
                            dr[PMKAK02005EA.Col_CashPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 102)
                        {
                            // 振込(金種区分)
                            dr[PMKAK02005EA.Col_TrfrPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 107)
                        {
                            // 小切手(金種区分)
                            dr[PMKAK02005EA.Col_CheckPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 105)
                        {
                            // 手形(金種区分)
                            dr[PMKAK02005EA.Col_DraftPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 106)
                        {
                            // 相殺(金種区分)
                            dr[PMKAK02005EA.Col_OffsetPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 112)
                        {
                            // 口座振替(金種区分)
                            dr[PMKAK02005EA.Col_FundTransferPayment] = work.Payment;
                        }
                        else
                        {
                            // その他(金種区分)
                            dr[PMKAK02005EA.Col_OthsPayment] = (long)dr[PMKAK02005EA.Col_OthsPayment] + work.Payment;
                        }
                    }
                }

				// TableにAdd
				suplierPayMainDt.Rows.Add( dr );
			}
		}
		#endregion

        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="sumSuplierPayMainCndtn">UI抽出条件クラス</param>
        /// <param name="spaymainResWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力金額区分で今回支払額をチェックする。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(SumSuplierPayMainCndtn sumSuplierPayMainCndtn, RsltInfo_SumPaymentTotalWork spaymainResWork)
        {
            bool bRet = false;

            // 出力金額区分で今回支払額のチェック
            switch (sumSuplierPayMainCndtn.OutputMoneyDiv)
            {
                case 0: // 全て出力 
                    {
                        bRet = true;
                        break;
                    }
                case 1: // ０とプラス金額を出力
                    {
                        if (spaymainResWork.ThisTimePayNrml >= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case 2: // プラス金額のみ出力
                    {
                        if (spaymainResWork.ThisTimePayNrml > 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case 3: // ０のみ出力
                    {
                        if (spaymainResWork.ThisTimePayNrml == 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case 4: // プラス金額とマイナス金額を出力
                    {
                        if (spaymainResWork.ThisTimePayNrml != 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case 5: // ０とマイナス金額を出力
                    {
                        if (spaymainResWork.ThisTimePayNrml <= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case 6: // マイナス金額のみ出力
                    {
                        if (spaymainResWork.ThisTimePayNrml < 0)
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
        /// フィルター用の仕入合計残高を設定
        /// </summary>
        private void SetStockTotalPayBalanceFilter()
        {
            for (int i = 0; i < this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].Rows.Count; i++)
            {
                // 計上拠点コードと支払先コードでキー作成
                string sectionCd = (string)this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].Rows[i][PMKAK02005EA.Col_AddUpSecCode];
                int payeeCode = (int)this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].Rows[i][PMKAK02005EA.Col_PayeeCode];
                string key = sectionCd.TrimEnd() + "-" + payeeCode.ToString("d06");

                // 仕入合計残高の取得
                long stockTotalPayBalance = 0;
                if (stockTotalPayBalanceDic.ContainsKey(key))
                {
                    stockTotalPayBalance = stockTotalPayBalanceDic[key];
                }
                // 仕入合計残高(フィルター用)に設定
                this._suppayDs.Tables[PMKAK02005EA.Col_Tbl_SuplierPayMain].Rows[i][PMKAK02005EA.Col_StockTotalPayBalanceFilter] = stockTotalPayBalance;
            }
        }

		#endregion ◆ データ展開処理

        #region ◆　フィルター設定処理
        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="sumSuplierPayMainCndtn">UI抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 出力金額区分でDataViewに設定するフィルターを追加する。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private string SelectOutputMoneyDivFilter(SumSuplierPayMainCndtn sumSuplierPayMainCndtn)
        {
            string filter = "";

            switch (sumSuplierPayMainCndtn.OutputMoneyDiv)
            {
                case 0: // 全て出力 
                    break;
                case 1: // ０とプラス金額を出力
                    filter = String.Format("{0} >= {1}",
                        PMKAK02005EA.Col_StockTotalPayBalanceFilter,
                        0);
                    break;
                case 2: // プラス金額のみ出力
                    filter = String.Format("{0} > {1}",
                        PMKAK02005EA.Col_StockTotalPayBalanceFilter,
                        0);
                    break;
                case 3: // ０のみ出力
                    filter = String.Format("{0} = {1}",
                        PMKAK02005EA.Col_StockTotalPayBalanceFilter,
                        0);
                    break;
                case 4: // プラス金額とマイナス金額を出力
                    filter = String.Format("{0} <> {1}",
                        PMKAK02005EA.Col_StockTotalPayBalanceFilter,
                        0);
                    break;
                case 5: // ０とマイナス金額を出力
                    filter = String.Format("{0} <= {1}",
                        PMKAK02005EA.Col_StockTotalPayBalanceFilter,
                        0);
                    break;
                case 6: // マイナス金額のみ出力
                    filter = String.Format("{0} < {1}",
                        PMKAK02005EA.Col_StockTotalPayBalanceFilter,
                        0);
                    break;
                default:
                    break;
            }

            return filter;
        }

        /// <summary>
        /// フィルター設定処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : 支払先内訳が両方の場合にDataViewに設定するフィルターを追加する。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private string SelectTotalRecordOnlyFilter(string rowFilter)
        {
            string filter = "";

            // 既にフィルターが存在するか？
            if (rowFilter.Trim().Length == 0)
            {
                // 他のフィルター無し
                filter = String.Format("{0} = {1}",
                        PMKAK02005EA.Col_SupplierCd,
                        0);
            }
            else
            {
                // 他のフィルター有り
                filter = String.Format("{0} AND {1} = {2}",
                        rowFilter,
                        PMKAK02005EA.Col_SupplierCd,
                        0);
            }

            return filter;
        }
        #endregion

        /// <summary>
        /// 請求初期値設定データ読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note      : 請求初期値設定データの読込を行います。</br>
        /// <br>Programer : FSI東 隆史</br>
        /// <br>Date      : 2012/09/04</br>
        /// </remarks>
        public int ReadBillPrtSt(string enterpriseCode, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 請求初期値情報取得
                _billPrtSt = null;
                BillPrtSt billPrtSt;
                status = mBillPrtStAcs.Read(out billPrtSt, enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            _billPrtSt = billPrtSt;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            message = "請求初期値設定を行って下さい";
                            return status;
                        }
                    default:
                        message = "請求初期値設定の取得に失敗しました";
                        return status;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return status;
        }

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
	    /// <br>Programmer : FSI東 隆史</br>
	    /// <br>Date       : 2012/09/04</br>
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
