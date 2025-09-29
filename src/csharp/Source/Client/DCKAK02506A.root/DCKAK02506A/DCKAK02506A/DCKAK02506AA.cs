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
    /// 支払一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払一覧表で使用するデータを取得する。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.09.10</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.11.06</br>
    /// <br></br>
    /// </remarks>
	public class SuplierPayMainAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 支払一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public SuplierPayMainAcs()
		{
            this._iPaymentTableDB = (IPaymentTableDB)MediationPaymentTableDB.GetPaymentTableDB();
		}

		/// <summary>
		/// 支払一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
		static SuplierPayMainAcs()
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

            // 2009.03.19 30413 犬飼 請求初期値設定から末日印字区分の取得 >>>>>>START
            // 請求初期値設定アクセスクラスインスタンス化
            mBillPrtStAcs = new BillPrtStAcs();
            // 2009.03.19 30413 犬飼 請求初期値設定から末日印字区分の取得 <<<<<<END
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
        IPaymentTableDB _iPaymentTableDB;  

		private DataSet _suppayDs;				        // 仕入先支払データセット

        // 2009.01.22 30413 犬飼 仕入合計残高のキャッシュを追加 >>>>>>START
        // 仕入合計残高のキャッシュ
        private Dictionary<string, long> stockTotalPayBalanceDic;
        // 2009.01.22 30413 犬飼 仕入合計残高のキャッシュを追加 <<<<<<END

        // 2009.03.19 30413 犬飼 請求初期値設定から末日印字区分の取得 >>>>>>START
        /// <summary>請求初期値設定アクセスクラス</summary>
        private static BillPrtStAcs mBillPrtStAcs = null;
        /// <summary>請求初期値設定</summary>
        private static BillPrtSt _billPrtSt = null;
        // 2009.03.19 30413 犬飼 請求初期値設定から末日印字区分の取得 <<<<<<END
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
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int SearchSuplierPayMain(SuplierPayMainCndtn suplierpaymainCndtn, out string errMsg)
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
        /// <param name="suplierPayMainCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する支払データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private int SearchSuplierPayMainProc(SuplierPayMainCndtn suplierPayMainCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAK02505EA.CreateDataTableSuplierPayMain(ref this._suppayDs);
                ExtrInfo_PaymentTotalWork extrInfo_PaymentTotalWork = new ExtrInfo_PaymentTotalWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevSuplierPayMainCndtn(suplierPayMainCndtn, out extrInfo_PaymentTotalWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retSuplierPayMainList = null;
                status = this._iPaymentTableDB.SearchPaymentTable( out retSuplierPayMainList, extrInfo_PaymentTotalWork );
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // 2009.01.22 30413 犬飼 キャッシュの初期化 >>>>>>START
                        stockTotalPayBalanceDic = new Dictionary<string, long>();
                        // 2009.01.22 30413 犬飼 キャッシュの初期化 <<<<<<END
                        
						// データ展開処理
                        DevSuplierPayMainData(suplierPayMainCndtn, this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain], (ArrayList)retSuplierPayMainList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // 2008.11.28 30413 犬飼 フィルター設定をAクラスで実施 >>>>>>START
                        else
                        {
                            // 2009.01.22 30413 犬飼 出力金額区分のフィルターを設定 >>>>>>START
                            //if (suplierPayMainCndtn.PayeeDetail == 0)
                            //{
                            //    // 支払先内訳が両方
                            //    string filter = this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter;
                            //    this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter = this.SelectTotalRecordOnlyFilter(filter);
                            //}
                            // フィルター用の仕入合計残高を設定
                            SetStockTotalPayBalanceFilter();

                            // 出力金額区分のフィルター設定
                            this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter = this.SelectOutputMoneyDivFilter(suplierPayMainCndtn);

                            if (this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            }
                            else
                            {
                                if (suplierPayMainCndtn.PayeeDetail == 0)
                                {
                                    // 支払先内訳が両方
                                    string filter = this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter;
                                    this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView.RowFilter = this.SelectTotalRecordOnlyFilter(filter);
                                }
                            }
                            // 2009.01.22 30413 犬飼 出力金額区分のフィルターを設定 <<<<<<END
                        }
                        // 2008.11.28 30413 犬飼 フィルター設定をAクラスで実施 <<<<<<END

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
		/// <param name="suplierPayMainCndtn">UI抽出条件クラス</param>
		/// <param name="extrInfo_PaymentTotalWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevSuplierPayMainCndtn(SuplierPayMainCndtn suplierPayMainCndtn, out ExtrInfo_PaymentTotalWork extrInfo_PaymentTotalWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            extrInfo_PaymentTotalWork = new ExtrInfo_PaymentTotalWork();

			try
			{
				extrInfo_PaymentTotalWork.EnterpriseCode = suplierPayMainCndtn.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (suplierPayMainCndtn.PaymentAddupSecCodeList.Length != 0)
				{
					if ( suplierPayMainCndtn.IsSelectAllSection )
					{
						// 全社の時
                        extrInfo_PaymentTotalWork.PaymentAddupSecCodeList = null;
					}
					else
					{
                        extrInfo_PaymentTotalWork.PaymentAddupSecCodeList = suplierPayMainCndtn.PaymentAddupSecCodeList;
					}
				}
				else
				{
                    extrInfo_PaymentTotalWork.PaymentAddupSecCodeList = null;
				}

                // 2008.11.06 30413 犬飼 締日の変更 >>>>>>START
                //extrInfo_PaymentTotalWork.St_CAddUpUpdExecDate = suplierPayMainCndtn.St_CAddUpUpdExecDate; // 開始締日
                //extrInfo_PaymentTotalWork.Ed_CAddUpUpdExecDate = suplierPayMainCndtn.Ed_CAddUpUpdExecDate; // 終了締日
                extrInfo_PaymentTotalWork.CAddUpUpdExecDate = suplierPayMainCndtn.CAddUpUpdExecDate;        // 締日
                // 2008.11.06 30413 犬飼 締日の変更 <<<<<<END
                
                extrInfo_PaymentTotalWork.St_PayeeCode = suplierPayMainCndtn.St_PayeeCode;		           // 開始支払先コード
                extrInfo_PaymentTotalWork.Ed_PayeeCode = suplierPayMainCndtn.Ed_PayeeCode;		           // 終了支払先コード
                //extrInfo_PaymentTotalWork.Ed_PayeeCode = 999999;		           // 終了支払先コード
                
                // 支払先内訳
                extrInfo_PaymentTotalWork.PayeeItems = suplierPayMainCndtn.PayeeDetail;
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
		/// <param name="suplierPayMainCndtn">UI抽出条件クラス</param>
		/// <param name="suplierPayMainDt">展開対象DataTable</param>
		/// <param name="suplierPayMainWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 仕入先支払データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private void DevSuplierPayMainData(SuplierPayMainCndtn suplierPayMainCndtn, DataTable suplierPayMainDt, ArrayList suplierPayMainWork)
		{
			DataRow dr;
            foreach (RsltInfo_PaymentTotalWork spaymainResWork in suplierPayMainWork)
			{
                // 2009.01.22 30413 犬飼 以前の出力金額区分チェックはコメント化 >>>>>>START
                //// 出力金額区分チェック
                //if (!CheckOutputMoneyDiv(suplierPayMainCndtn, spaymainResWork))
                //{
                //    // 印刷対象データでは無い
                //    continue;
                //}
                // 2009.01.22 30413 犬飼 以前の出力金額区分チェックはコメント化 <<<<<<END
                
                // 2009.01.22 30413 犬飼 親支払先内訳の処理を追加 >>>>>>START
                if (suplierPayMainCndtn.PrPayeeDtl == 0)
                {
                    // 支払先に含む
                    if ((suplierPayMainCndtn.PayeeDetail == 0) || (suplierPayMainCndtn.PayeeDetail == 2))
                    {
                        // 2009.02.06 30413 犬飼 計上拠点と実績拠点を比較対象に追加 >>>>>>START
                        // 支払先内訳が"両方"または"仕入先"
                        //if (spaymainResWork.PayeeCode == spaymainResWork.SupplierCd)
                        if ((spaymainResWork.PayeeCode == spaymainResWork.SupplierCd) &&
                            (spaymainResWork.AddUpSecCode.TrimEnd().Equals(spaymainResWork.ResultsSectCd.TrimEnd())))
                        {
                            // 印刷対象データでは無い
                            continue;
                        }
                        // 2009.02.06 30413 犬飼 計上拠点と実績拠点を比較対象に追加 <<<<<<END
                    }
                }
                // 2009.01.22 30413 犬飼 親支払先内訳の処理を追加 <<<<<<END
                
                dr = suplierPayMainDt.NewRow();
			    
                // 2008.11.06 30413 犬飼 抽出結果の展開処理を修正 >>>>>>START
                // 計上拠点コード
                dr[DCKAK02505EA.Col_AddUpSecCode] = spaymainResWork.AddUpSecCode;
                //// 計上拠点名称
                //if ( suplierPayMainCndtn.IsSelectAllSection)
                //    dr[DCKAK02505EA.Col_AddUpSecName] = "全社";
                //else
                //    dr[DCKAK02505EA.Col_AddUpSecName] = spaymainResWork.AddUpSecName.TrimEnd();
                dr[DCKAK02505EA.Col_AddUpSecName] = spaymainResWork.AddUpSecName.TrimEnd();
                // 計上拠点名称(明細)
				dr[DCKAK02505EA.Col_AddUpSecName_Detail] = spaymainResWork.AddUpSecName.TrimEnd();
                // 2009.01.27 30413 犬飼 実績拠点コードの追加 >>>>>>START
                // 実績拠点コード
                dr[DCKAK02505EA.Col_ResultsSectCd] = spaymainResWork.ResultsSectCd;
                // 2009.01.27 30413 犬飼 実績拠点コードの追加 <<<<<<END
                // 支払先コード
                dr[DCKAK02505EA.Col_PayeeCode] = spaymainResWork.PayeeCode;
                // 支払先名称
                dr[DCKAK02505EA.Col_PayeeName] = spaymainResWork.PayeeName;
                // 支払先名称2
                dr[DCKAK02505EA.Col_PayeeName2] = spaymainResWork.PayeeName2;
                // 支払先略称
                dr[DCKAK02505EA.Col_PayeeSnm] = spaymainResWork.PayeeSnm;
                // 仕入先コード
                dr[DCKAK02505EA.Col_SupplierCd] = spaymainResWork.SupplierCd;
                // 仕入先名1
                dr[DCKAK02505EA.Col_SupplierNm1] = spaymainResWork.SupplierNm1;
                // 仕入先名2
                dr[DCKAK02505EA.Col_SupplierNm2] = spaymainResWork.SupplierNm2;
                // 仕入先略称
                dr[DCKAK02505EA.Col_SupplierSnm] = spaymainResWork.SupplierSnm;
                // 計上年月日(表示用)
                dr[DCKAK02505EA.Col_AddUpDate] = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, spaymainResWork.AddUpDate);
                // 計上年月日(ソート用)
                dr[DCKAK02505EA.Col_Sort_AddUpDate] = TDateTime.DateTimeToLongDate(spaymainResWork.AddUpDate);
                // 計上年月(表示用)
                dr[DCKAK02505EA.Col_AddUpYearMonth] = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, spaymainResWork.AddUpYearMonth);
                // 計上年月(ソート用)
                dr[DCKAK02505EA.Col_Sort_AddUpYearMonth] = TDateTime.DateTimeToLongDate(spaymainResWork.AddUpYearMonth);
                // 前回支払金額
                dr[DCKAK02505EA.Col_LastTimePayment] = spaymainResWork.LastTimePayment;
                // 仕入2回前残高（支払計）
                dr[DCKAK02505EA.Col_StockTtl2TmBfBlPay] = spaymainResWork.StockTtl2TmBfBlPay;
                // 仕入3回前残高（支払計）
                dr[DCKAK02505EA.Col_StockTtl3TmBfBlPay] = spaymainResWork.StockTtl3TmBfBlPay;
                // 今回支払金額(通常支払)
                dr[DCKAK02505EA.Col_ThisTimePayNrml] = spaymainResWork.ThisTimePayNrml;
                // 今回繰越残高
                dr[DCKAK02505EA.Col_ThisTimeTtlBlcPay] = spaymainResWork.ThisTimeTtlBlcPay;
                // 相殺後今回仕入金額
                dr[DCKAK02505EA.Col_OfsThisTimeStock] = spaymainResWork.OfsThisTimeStock;
                // 相殺後今回仕入消費税
                dr[DCKAK02505EA.Col_OfsThisStockTax] = spaymainResWork.OfsThisStockTax;
                // 2009.01.29 30413 犬飼 今回仕入金額の復活 >>>>>>START
                // 今回仕入金額
                dr[DCKAK02505EA.Col_ThisTimeStockPrice] = spaymainResWork.ThisTimeStockPrice;
                // 2009.01.29 30413 犬飼 今回仕入金額の復活 <<<<<<END
                //// 今回仕入消費税
                //dr[DCKAK02505EA.Col_ThisStcPrcTax] = spaymainResWork.ThisStcPrcTax;
                // 今回返品金額
                dr[DCKAK02505EA.Col_ThisStckPricRgds] = spaymainResWork.ThisStckPricRgds;
                //// 今回返品消費税
                //dr[DCKAK02505EA.Col_ThisStcPrcTaxRgds] = spaymainResWork.ThisStcPrcTaxRgds;
                // 今回値引金額
                dr[DCKAK02505EA.Col_ThisStckPricDis] = spaymainResWork.ThisStckPricDis;
                //// 今回値引消費税
                //dr[DCKAK02505EA.Col_ThisStcPrcTaxDis] = spaymainResWork.ThisStcPrcTaxDis;
                //// 消費税調整額
                //dr[DCKAK02505EA.Col_TaxAdjust] = spaymainResWork.TaxAdjust;
                //// 残高調整額
                //dr[DCKAK02505EA.Col_BalanceAdjust] = spaymainResWork.BalanceAdjust;
                // 仕入合計残高
                dr[DCKAK02505EA.Col_StockTotalPayBalance] = spaymainResWork.StockTotalPayBalance;

                // 2009.01.22 30413 犬飼 仕入合計残高(フィルター用)を追加 >>>>>>START
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
                // 2009.01.22 30413 犬飼 仕入合計残高(フィルター用)を追加 <<<<<<END

                //// 締次更新実行年月日(表示用)
                //dr[DCKAK02505EA.Col_CAddUpUpdExecDate] = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, spaymainResWork.CAddUpUpdExecDate);
                //// 締次更新実行年月日(ソート用)
                //dr[DCKAK02505EA.Col_Sort_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(spaymainResWork.CAddUpUpdExecDate);
                //// 締次更新開始年月日(表示用)
                //dr[DCKAK02505EA.Col_StartCAddUpUpdDate] = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, spaymainResWork.StartCAddUpUpdDate);
                //// 締次更新開始年月日(ソート用)
                //dr[DCKAK02505EA.Col_Sort_StartCAddUpUpdDate] = TDateTime.DateTimeToLongDate(spaymainResWork.StartCAddUpUpdDate);
                // 仕入伝票枚数
                dr[DCKAK02505EA.Col_StockSlipCount] = spaymainResWork.StockSlipCount;
                // 今回手数料額（通常支払）
                dr[DCKAK02505EA.Col_ThisTimeFeePayNrml] = spaymainResWork.ThisTimeFeePayNrml;
                // 今回値引額（通常支払）
                dr[DCKAK02505EA.Col_ThisTimeDisPayNrml] = spaymainResWork.ThisTimeDisPayNrml;
                // 支払月区分名称
                dr[DCKAK02505EA.Col_PaymentMonthName] = spaymainResWork.PaymentMonthName;
                // 2009.03.19 30413 犬飼 請求書末日印字区分から判定するように修正 >>>>>>START
                // 2009.02.16 30413 犬飼 末日印字設定 >>>>>>START
                // 支払日
                //dr[DCKAK02505EA.Col_PaymentDay] = spaymainResWork.PaymentDay;
                // 請求書末日印字区分 = 1(28～31日は末日と印字) で28日以降の場合
                //if (spaymainResWork.PaymentDay >= 28)
                if (spaymainResWork.PaymentDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                {
                    dr[DCKAK02505EA.Col_PaymentDay] = "末";
                }
                else
                {
                    dr[DCKAK02505EA.Col_PaymentDay] = spaymainResWork.PaymentDay.ToString();
                }
                // 2009.02.16 30413 犬飼 末日印字設定 <<<<<<END
                // 2009.03.19 30413 犬飼 請求書末日印字区分から判定するように修正 <<<<<<END
                
                //// 今回合計
                //dr[DCKAK02505EA.Col_ThisTotal] = spaymainResWork.OfsThisTimeStock + spaymainResWork.OfsThisStockTax;

                // 計算金額(印字用)
                // 支払残高
                dr[DCKAK02505EA.Col_PaymentBalance] = spaymainResWork.LastTimePayment
                                                    + spaymainResWork.StockTtl2TmBfBlPay
                                                    + spaymainResWork.StockTtl3TmBfBlPay;

                // 2009.02.05 30413 犬飼 符号を逆に修正 >>>>>>START
                long retGoodsDiscount = spaymainResWork.ThisStckPricRgds + spaymainResWork.ThisStckPricDis;
                // 返品値引
                //dr[DCKAK02505EA.Col_RetGoodsDiscount] = retGoodsDiscount;
                dr[DCKAK02505EA.Col_RetGoodsDiscount] = -retGoodsDiscount;
                // 2009.02.05 30413 犬飼 符号を逆に修正 <<<<<<END
            
                // 2009.01.29 30413 犬飼 純仕入額は相殺後今回仕入金額に修正 >>>>>>START
                //long pureCost = spaymainResWork.OfsThisTimeStock + retGoodsDiscount;
                long pureCost = spaymainResWork.OfsThisTimeStock;
                // 純仕入額
                dr[DCKAK02505EA.Col_PureCost] = pureCost;
                // 2009.01.29 30413 犬飼 純仕入額は相殺後今回仕入金額に修正 <<<<<<END

                // 2009.01.29 30413 犬飼 今回合計の計算を変更 >>>>>>START
                // 2008.12.08 30413 犬飼 今回合計の計算を変更 >>>>>>START
                // 今回合計
                //dr[DCKAK02505EA.Col_ThisTotal] = pureCost + spaymainResWork.OfsThisTimeStock + spaymainResWork.OfsThisStockTax;
                //// 今回合計(今回繰越残高+純仕入額+相殺後今回仕入消費税)
                //dr[DCKAK02505EA.Col_ThisTotal] = spaymainResWork.ThisTimeTtlBlcPay + pureCost + spaymainResWork.OfsThisStockTax;
                // 今回合計(純仕入額+相殺後今回仕入消費税)
                dr[DCKAK02505EA.Col_ThisTotal] = pureCost + spaymainResWork.OfsThisStockTax;
                // 2008.12.08 30413 犬飼 今回合計の計算を変更 <<<<<<END
                // 2009.01.29 30413 犬飼 今回合計の計算を変更 <<<<<<END
                
                // 2008.11.13 30413 犬飼 金種の初期値を設定 >>>>>>START
                // 現金(金種区分)
                dr[DCKAK02505EA.Col_CashPayment] = 0;
                // 振込(金種区分)
                dr[DCKAK02505EA.Col_TrfrPayment] = 0;
                // 小切手(金種区分)
                dr[DCKAK02505EA.Col_CheckPayment] = 0;
                // 手形(金種区分)
                dr[DCKAK02505EA.Col_DraftPayment] = 0;
                // 相殺(金種区分)
                dr[DCKAK02505EA.Col_OffsetPayment] = 0;
                // 口座振替(金種区分)
                dr[DCKAK02505EA.Col_FundTransferPayment] = 0;
                // その他
                dr[DCKAK02505EA.Col_OthsPayment] = 0;
                // 2008.11.13 30413 犬飼 金種の初期値を設定 <<<<<<END

                // 金種コード
                if (spaymainResWork.MoneyKindList != null)
                {
                    foreach (RsltInfo_AccPayTotalWork work in spaymainResWork.MoneyKindList)
                    {
                        if (work.MoneyKindDiv == 101)
                        {
                            // 現金(金種区分)
                            dr[DCKAK02505EA.Col_CashPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 102)
                        {
                            // 振込(金種区分)
                            dr[DCKAK02505EA.Col_TrfrPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 107)
                        {
                            // 小切手(金種区分)
                            dr[DCKAK02505EA.Col_CheckPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 105)
                        {
                            // 手形(金種区分)
                            dr[DCKAK02505EA.Col_DraftPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 106)
                        {
                            // 相殺(金種区分)
                            dr[DCKAK02505EA.Col_OffsetPayment] = work.Payment;
                        }
                        else if (work.MoneyKindDiv == 112)
                        {
                            // 口座振替(金種区分)
                            dr[DCKAK02505EA.Col_FundTransferPayment] = work.Payment;
                        }
                        else
                        {
                            // その他(金種区分)
                            dr[DCKAK02505EA.Col_OthsPayment] = (long)dr[DCKAK02505EA.Col_OthsPayment] + work.Payment;
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
        /// <param name="suplierPayMainCndtn">UI抽出条件クラス</param>
        /// <param name="spaymainResWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力金額区分で今回支払額をチェックする。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(SuplierPayMainCndtn suplierPayMainCndtn, RsltInfo_PaymentTotalWork spaymainResWork)
        {
            bool bRet = false;

            // 出力金額区分で今回支払額のチェック
            switch (suplierPayMainCndtn.OutputMoneyDiv)
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
            for (int i = 0; i < this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].Rows.Count; i++)
            {
                // 計上拠点コードと支払先コードでキー作成
                string sectionCd = (string)this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].Rows[i][DCKAK02505EA.Col_AddUpSecCode];
                int payeeCode = (int)this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].Rows[i][DCKAK02505EA.Col_PayeeCode];
                string key = sectionCd.TrimEnd() + "-" + payeeCode.ToString("d06");

                // 仕入合計残高の取得
                long stockTotalPayBalance = 0;
                if (stockTotalPayBalanceDic.ContainsKey(key))
                {
                    stockTotalPayBalance = stockTotalPayBalanceDic[key];
                }
                // 仕入合計残高(フィルター用)に設定
                this._suppayDs.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].Rows[i][DCKAK02505EA.Col_StockTotalPayBalanceFilter] = stockTotalPayBalance;
            }
        }

		#endregion ◆ データ展開処理

        #region ◆　フィルター設定処理
        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="suplierPayMainCndtn">UI抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 出力金額区分でDataViewに設定するフィルターを追加する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.22</br>
        /// </remarks>
        private string SelectOutputMoneyDivFilter(SuplierPayMainCndtn suplierPayMainCndtn)
        {
            string filter = "";

            // 仕入合計残高(フィルター用)でフィルター条件作成
            if (suplierPayMainCndtn.PayeeDetail != 2)
            {
                switch (suplierPayMainCndtn.OutputMoneyDiv)
                {
                    case 0: // 全て出力 
                        break;
                    case 1: // ０とプラス金額を出力
                        filter = String.Format("{0} >= {1}",
                            DCKAK02505EA.Col_StockTotalPayBalanceFilter,
                            0);
                        break;
                    case 2: // プラス金額のみ出力
                        filter = String.Format("{0} > {1}",
                            DCKAK02505EA.Col_StockTotalPayBalanceFilter,
                            0);
                        break;
                    case 3: // ０のみ出力
                        filter = String.Format("{0} = {1}",
                            DCKAK02505EA.Col_StockTotalPayBalanceFilter,
                            0);
                        break;
                    case 4: // プラス金額とマイナス金額を出力
                        filter = String.Format("{0} <> {1}",
                            DCKAK02505EA.Col_StockTotalPayBalanceFilter,
                            0);
                        break;
                    case 5: // ０とマイナス金額を出力
                        filter = String.Format("{0} <= {1}",
                            DCKAK02505EA.Col_StockTotalPayBalanceFilter,
                            0);
                        break;
                    case 6: // マイナス金額のみ出力
                        filter = String.Format("{0} < {1}",
                            DCKAK02505EA.Col_StockTotalPayBalanceFilter,
                            0);
                        break;
                    default:
                        break;
                }
            }

            return filter;
        }

        /// <summary>
        /// フィルター設定処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : 支払先内訳が両方の場合にDataViewに設定するフィルターを追加する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.28</br>
        /// </remarks>
        private string SelectTotalRecordOnlyFilter(string rowFilter)
        {
            string filter = "";

            // 既にフィルターが存在するか？
            if (rowFilter.Trim().Length == 0)
            {
                // 他のフィルター無し
                filter = String.Format("{0} = {1}",
                        DCKAK02505EA.Col_SupplierCd,
                        0);
            }
            else
            {
                // 他のフィルター有り
                filter = String.Format("{0} AND {1} = {2}",
                        rowFilter,
                        DCKAK02505EA.Col_SupplierCd,
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
        /// <br>Note       : 請求初期値設定データの読込を行います。</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2009.03.19</br>
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
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
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
