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
// --- ADD 2012/10/01 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/10/01 ----------<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 買掛残高一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高一覧表で使用するデータを取得する。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.10.24</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.01</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/03/02</br>
    /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/10/09</br>
    /// </remarks>
	public class AccPaymentListAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 買掛残高一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 買掛残高一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
		public AccPaymentListAcs()
		{
            this._iAccPaymentListWorkDB = (IAccPaymentListWorkDB)MediationAccPaymentListWorkDB.GetAccPaymentListWorkDB();
		}

		/// <summary>
		/// 買掛残高一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 買掛残高一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.10.24</br>
        /// <br></br>
        /// <br>Note       : 仕入先総括対応に伴う対応</br>
        /// <br>Programmer : 30755 FSI菅原(庸)</br>
        /// <br>Date       : 2012/10/01</br>
		/// </remarks>
		static AccPaymentListAcs()
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
        private IAccPaymentListWorkDB _iAccPaymentListWorkDB;

		private DataSet _AccPaymentListDs;				    // 仕入先買掛データセット

        // 2009.02.10 30413 犬飼 拠点毎に月次締未更新キャッシュ >>>>>>START
        private Dictionary<string, bool> _monAddUpNonProcDic;
        // 2009.02.10 30413 犬飼 拠点毎に月次締未更新キャッシュ <<<<<<END
        
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
        /// 仕入先買掛金額データセット(読み取り専用)
		/// </summary>
		public DataSet CustAccRecDs
		{
			get{ return this._AccPaymentListDs; }
		}
        // --- ADD 2012/10/01 ---------->>>>>
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 1,
            /// <summary>有効</summary>
            ON = 2,
        }
        // --- ADD 2012/10/01 ----------<<<<<
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
        #region ◎ 仕入先買掛金額データ取得
        /// <summary>
        /// 仕入先買掛金額データ取得
		/// </summary>
        /// <param name="accPaymentListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する仕入先買掛金額データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
        public int SearchCustAccRecMain(AccPaymentListCndtn accPaymentListCndtn, out string errMsg)
		{
            return this.SearchProc(accPaymentListCndtn, out errMsg);
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
        /// <param name="accPaymentListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.10.24</br>
		/// </remarks>
        private int SearchProc(AccPaymentListCndtn accPaymentListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAK02644EA.CreateDataTable(ref this._AccPaymentListDs);
                
                AccPaymentListCndtnWork accPaymentListCndtnWork = new AccPaymentListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevAccPaymentListCndtn(accPaymentListCndtn, out accPaymentListCndtnWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retCustAccRecMainList = null;

                status = this._iAccPaymentListWorkDB.Search( out retCustAccRecMainList, accPaymentListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0 );
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 2009.02.10 30413 犬飼 キャッシュの初期化 >>>>>>START
                        _monAddUpNonProcDic = new Dictionary<string, bool>();
                        // 2009.02.10 30413 犬飼 キャッシュの初期化 <<<<<<END
                        
                        // データ展開処理
                        DevListData(accPaymentListCndtn, this._AccPaymentListDs.Tables[DCKAK02644EA.ct_Tbl_AccPaymentList], (ArrayList)retCustAccRecMainList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (this._AccPaymentListDs.Tables[DCKAK02644EA.ct_Tbl_AccPaymentList].Rows.Count == 0)
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
		/// <param name="accPaymentListCndtn">UI抽出条件クラス</param>
		/// <param name="accPaymentListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/03/02</br>
        private int DevAccPaymentListCndtn(AccPaymentListCndtn accPaymentListCndtn, out AccPaymentListCndtnWork accPaymentListCndtnWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            accPaymentListCndtnWork = new AccPaymentListCndtnWork();

			try
			{
                // --- ADD 2012/10/01 ---------->>>>>
                // 仕入先総括のオプションコード利用可否取得
                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    accPaymentListCndtnWork.OptSuppEnable = (int)Option.ON;
                }
                else
                {
                    accPaymentListCndtnWork.OptSuppEnable = (int)Option.OFF;
                }
                // --- ADD 2012/10/01 ----------<<<<<
                // 2008.10.06 30413 犬飼 抽出条件プロパティの変更 >>>>>>START
                accPaymentListCndtnWork.EnterpriseCode = accPaymentListCndtn.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (accPaymentListCndtn.SectionCodes.Length != 0)
				{
					if ( accPaymentListCndtn.IsSelectAllSection )
					{
						// 全社の時
                        accPaymentListCndtnWork.SectionCodes = null;
					}
					else
					{
                        accPaymentListCndtnWork.SectionCodes = accPaymentListCndtn.SectionCodes;
					}
				}
				else
				{
                    accPaymentListCndtnWork.SectionCodes = null;
				}
                                          
                accPaymentListCndtnWork.EnterpriseCode = accPaymentListCndtn.EnterpriseCode; // 企業コード
                accPaymentListCndtnWork.SectionCodes = accPaymentListCndtn.SectionCodes; // 拠点コード（複数指定）
                accPaymentListCndtnWork.AddUpYearMonth = accPaymentListCndtn.AddUpYearMonth; // 計上年月
                accPaymentListCndtnWork.St_PayeeCode = accPaymentListCndtn.St_PayeeCode; // 開始請求先コード
                if (accPaymentListCndtn.Ed_PayeeCode == 0)
                {
                    // 未入力の場合は、最大値をセット
                    accPaymentListCndtnWork.Ed_PayeeCode = 999999;                           // 終了請求先コード
                }
                else
                {
                    accPaymentListCndtnWork.Ed_PayeeCode = accPaymentListCndtn.Ed_PayeeCode; // 終了請求先コード
                }
                // 2009.02.10 30413 犬飼 出力金額区分はUI側で処理 >>>>>>START
                //accPaymentListCndtnWork.OutMoneyDiv = (int)accPaymentListCndtn.OutMoneyDiv; // 出力金額区分
                // 2009.02.10 30413 犬飼 出力金額区分はUI側で処理 <<<<<<END
                accPaymentListCndtnWork.AddUpDate = accPaymentListCndtn.AddUpDate;  // 計上年月日
                accPaymentListCndtnWork.PayDtlDiv = accPaymentListCndtn.PayDtlDiv;  // 支払内訳区分
                // 2008.10.06 30413 犬飼 抽出条件プロパティの変更 <<<<<<END

                // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
                // 税別内訳印字区分
                accPaymentListCndtnWork.TaxPrintDiv = accPaymentListCndtn.TaxPrintDiv;
                // 税率1
                accPaymentListCndtnWork.TaxRate1 = accPaymentListCndtn.TaxRate1;
                // 税率2
                accPaymentListCndtnWork.TaxRate2 = accPaymentListCndtn.TaxRate2;
                // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
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
		/// <param name="accPaymentListCndtn">UI抽出条件クラス</param>
		/// <param name="accPaymentTable">展開対象DataTable</param>
        /// <param name="accPaymentListResultWorkList">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 仕入先買掛データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.10.24</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/03/02</br>
        /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2022/10/09</br>
		/// </remarks>
        private void DevListData(AccPaymentListCndtn accPaymentListCndtn, DataTable accPaymentTable, ArrayList accPaymentListResultWorkList)
		{
			DataRow dr;
            foreach ( AccPaymentListResultWork accPaymentListResultWork in accPaymentListResultWorkList )
			{
                // 出力金額区分チェック
                if (!CheckOutputMoneyDiv(accPaymentListCndtn, accPaymentListResultWork))
                {
                    // 印刷対象データでは無い
                    continue;
                }

                dr = accPaymentTable.NewRow();

                // 2008.10.02 30413 犬飼 抽出結果プロパティの変更 >>>>>>START
                dr[DCKAK02644EA.ct_Col_AddUpSecCode] = accPaymentListResultWork.AddUpSecCode; // 計上拠点コード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if ( accPaymentListCndtn.IsSelectAllSection )
                //{
                //    dr[DCKAK02644EA.ct_Col_SectionGuideNm] = "全社"; // 計上拠点名称：全社
                //}
                //else
                //{
                //    dr[DCKAK02644EA.ct_Col_SectionGuideNm] = accPaymentListResultWork.SectionGuideNm; // 計上拠点名称
                //}
                //dr[DCKAK02644EA.ct_Col_SectionGuideNm] = accPaymentListResultWork.SectionGuideNm; // 計上拠点名称
                dr[DCKAK02644EA.ct_Col_SectionGuideNm] = accPaymentListResultWork.SectionGuideSnm; // 計上拠点名称
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                dr[DCKAK02644EA.ct_Col_PayeeCode] = accPaymentListResultWork.PayeeCode; // 支払先コード
                //dr[DCKAK02644EA.ct_Col_PayeeName] = accPaymentListResultWork.PayeeName; // 支払先名称
                //dr[DCKAK02644EA.ct_Col_PayeeName2] = accPaymentListResultWork.PayeeName2; // 支払先名称2
                dr[DCKAK02644EA.ct_Col_PayeeSnm] = accPaymentListResultWork.PayeeSnm; // 支払先略称
                dr[DCKAK02644EA.ct_Col_LastTimeAccPay] = accPaymentListResultWork.LastTimeAccPay; // 前回買掛金額
                dr[DCKAK02644EA.ct_Col_ThisTimePayNrml] = accPaymentListResultWork.ThisTimePayNrml; // 今回支払金額（通常支払）
                dr[DCKAK02644EA.ct_Col_ThisTimeFeePayNrml] = accPaymentListResultWork.ThisTimeFeePayNrml; // 今回手数料額（通常支払）
                dr[DCKAK02644EA.ct_Col_ThisTimeDisPayNrml] = accPaymentListResultWork.ThisTimeDisPayNrml; // 今回値引額（通常支払）
                dr[DCKAK02644EA.ct_Col_ThisTimeTtlBlcAcPay] = accPaymentListResultWork.ThisTimeTtlBlcAcPay; // 今回繰越残高（買掛計）
                dr[DCKAK02644EA.ct_Col_OfsThisTimeStock] = accPaymentListResultWork.OfsThisTimeStock; // 相殺後今回仕入金額
                // 2009.02.05 30413 犬飼 符号を逆に修正 >>>>>>START
                //dr[DCKAK02644EA.ct_Col_ThisRgdsDisPric] = accPaymentListResultWork.ThisRgdsDisPric; // 返品値引
                long thisRgdsDisPric = accPaymentListResultWork.ThisRgdsDisPric;
                dr[DCKAK02644EA.ct_Col_ThisRgdsDisPric] = -thisRgdsDisPric; // 返品値引
                // 2009.02.05 30413 犬飼 符号を逆に修正 <<<<<<END
                dr[DCKAK02644EA.ct_Col_OfsThisStockTax] = accPaymentListResultWork.OfsThisStockTax; // 相殺後今回仕入消費税
                // 2009.01.29 30413 犬飼 今回仕入金額の復活 >>>>>>START
                dr[DCKAK02644EA.ct_Col_ThisTimeStockPrice] = accPaymentListResultWork.ThisTimeStockPrice; // 今回仕入金額
                // 2009.01.29 30413 犬飼 今回仕入金額の復活 <<<<<<END
                //dr[DCKAK02644EA.ct_Col_ThisStcPrcTax] = accPaymentListResultWork.ThisStcPrcTax; // 今回仕入消費税
                //dr[DCKAK02644EA.ct_Col_ThisStckPricRgds] = accPaymentListResultWork.ThisStckPricRgds; // 今回返品金額
                //dr[DCKAK02644EA.ct_Col_ThisStcPrcTaxRgds] = accPaymentListResultWork.ThisStcPrcTaxRgds; // 今回返品消費税
                //dr[DCKAK02644EA.ct_Col_ThisStckPricDis] = accPaymentListResultWork.ThisStckPricDis; // 今回値引金額
                //dr[DCKAK02644EA.ct_Col_ThisStcPrcTaxDis] = accPaymentListResultWork.ThisStcPrcTaxDis; // 今回値引消費税
                //dr[DCKAK02644EA.ct_Col_ThisRecvOffset] = accPaymentListResultWork.ThisRecvOffset; // 今回受取金額
                //dr[DCKAK02644EA.ct_Col_ThisRecvOffsetTax] = accPaymentListResultWork.ThisRecvOffsetTax; // 今回受取相殺消費税
                //dr[DCKAK02644EA.ct_Col_TaxAdjust] = accPaymentListResultWork.TaxAdjust; // 消費税調整額
                //dr[DCKAK02644EA.ct_Col_BalanceAdjust] = accPaymentListResultWork.BalanceAdjust; // 残高調整額
                dr[DCKAK02644EA.ct_Col_StckTtlAccPayBalance] = accPaymentListResultWork.StckTtlAccPayBalance; // 仕入合計残高（買掛計）
                dr[DCKAK02644EA.ct_Col_StockSlipCount] = accPaymentListResultWork.StockSlipCount; // 仕入伝票枚数
                //dr[DCKAK02644EA.ct_Col_PaymentCond] = accPaymentListResultWork.PaymentCond; // 支払条件
                //dr[DCKAK02644EA.ct_Col_PaymentTotalDay] = accPaymentListResultWork.PaymentTotalDay; // 支払締日
                //dr[DCKAK02644EA.ct_Col_PaymentMonthName] = accPaymentListResultWork.PaymentMonthName; // 支払月区分名称
                //dr[DCKAK02644EA.ct_Col_PaymentDay] = accPaymentListResultWork.PaymentDay; // 支払日
                dr[DCKAK02644EA.ct_Col_CashPayment] = accPaymentListResultWork.CashPayment; // 現金
                dr[DCKAK02644EA.ct_Col_TrfrPayment] = accPaymentListResultWork.TrfrPayment; // 振込
                dr[DCKAK02644EA.ct_Col_CheckPayment] = accPaymentListResultWork.CheckPayment; // 小切手
                dr[DCKAK02644EA.ct_Col_DraftPayment] = accPaymentListResultWork.DraftPayment; // 手形
                dr[DCKAK02644EA.ct_Col_OffsetPayment] = accPaymentListResultWork.OffsetPayment; // 相殺
                dr[DCKAK02644EA.ct_Col_FundTransferPayment] = accPaymentListResultWork.FundTransferPayment; // 口座振替
                dr[DCKAK02644EA.ct_Col_OthsPayment] = accPaymentListResultWork.OthsPayment; // その他

                // 2009.01.29 30413 犬飼 純売上額の計算を変更 >>>>>>START
                //// 純仕入額を追加(相殺後今回仕入金額+返品値引)
                //long pureStock = accPaymentListResultWork.OfsThisTimeStock + accPaymentListResultWork.ThisRgdsDisPric;
                // 純仕入額を追加(相殺後今回仕入金額)
                long pureStock = accPaymentListResultWork.OfsThisTimeStock;
                dr[DCKAK02644EA.ct_Col_PureStock] = pureStock;
                // 2009.01.29 30413 犬飼 純売上額の計算を変更 <<<<<<END
                
                // ※印刷用の追加項目をセット
                //dr[DCKAK02644EA.ct_Col_ThisStockPricRgdsDis] = accPaymentListResultWork.ThisStckPricRgds
                //                                               + accPaymentListResultWork.ThisStckPricDis; // 今回返品値引金額
                //dr[DCKAK02644EA.ct_Col_StockPricTax] = accPaymentListResultWork.OfsThisTimeStock
                //                                               + accPaymentListResultWork.OfsThisStockTax; // 今回合計金額
                // 2009.01.29 30413 犬飼 今回合計金額の計算を変更 >>>>>>START
                //// 今回合計金額(今回繰越残高+純仕入額+消費税)
                //dr[DCKAK02644EA.ct_Col_StockPricTax] = accPaymentListResultWork.ThisTimeTtlBlcAcPay + pureStock + accPaymentListResultWork.OfsThisStockTax;
                // 今回合計金額(純仕入額+消費税)
                dr[DCKAK02644EA.ct_Col_StockPricTax] = pureStock + accPaymentListResultWork.OfsThisStockTax;
                // 2009.01.29 30413 犬飼 今回合計金額の計算を変更 <<<<<<END
                // 2008.10.02 30413 犬飼 抽出結果プロパティの変更 <<<<<<END

                // 2009.02.10 30413 犬飼 拠点毎に暫定消費税の文言を表示制御 >>>>>>START
                // 月次締未更新チェック
                dr[DCKAK02644EA.Col_MonAddUpNonProc] = CheckMonAddUpNonProc(accPaymentListCndtn, accPaymentListResultWork);
                // 2009.02.10 30413 犬飼 拠点毎に暫定消費税の文言を表示制御 <<<<<<END

                // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
                // 仕入額(計税率1)
                dr[DCKAK02644EA.Col_TotalThisTimeStockPriceTaxRate1] = accPaymentListResultWork.TotalThisTimeStockPriceTaxRate1;
                // 仕入額(計税率2)
                dr[DCKAK02644EA.Col_TotalThisTimeStockPriceTaxRate2] = accPaymentListResultWork.TotalThisTimeStockPriceTaxRate2;
                // 仕入額(計その他)
                dr[DCKAK02644EA.Col_TotalThisTimeStockPriceOther] = accPaymentListResultWork.TotalThisTimeStockPriceOther;
                // 返品値引(計税率1)
                dr[DCKAK02644EA.Col_TotalThisRgdsDisPricTaxRate1] = accPaymentListResultWork.TotalThisRgdsDisPricTaxRate1;
                // 返品値引(計税率2)
                dr[DCKAK02644EA.Col_TotalThisRgdsDisPricTaxRate2] = accPaymentListResultWork.TotalThisRgdsDisPricTaxRate2;
                // 返品値引(計その他)
                dr[DCKAK02644EA.Col_TotalThisRgdsDisPricOther] = accPaymentListResultWork.TotalThisRgdsDisPricOther;
                // 純仕入額(計税率1)
                dr[DCKAK02644EA.Col_TotalPureStockTaxRate1] = accPaymentListResultWork.TotalPureStockTaxRate1;
                // 純仕入額(計税率2)
                dr[DCKAK02644EA.Col_TotalPureStockTaxRate2] = accPaymentListResultWork.TotalPureStockTaxRate2;
                // 純仕入額(計その他)
                dr[DCKAK02644EA.Col_TotalPureStockOther] = accPaymentListResultWork.TotalPureStockOther;
                // 消費税(計税率1)
                dr[DCKAK02644EA.Col_TotalStockPricTaxTaxRate1] = accPaymentListResultWork.TotalStockPricTaxTaxRate1;
                // 消費税(計税率2)
                dr[DCKAK02644EA.Col_TotalStockPricTaxTaxRate2] = accPaymentListResultWork.TotalStockPricTaxTaxRate2;
                // 消費税(計その他)
                dr[DCKAK02644EA.Col_TotalStockPricTaxOther] = accPaymentListResultWork.TotalStockPricTaxOther;
                // 当月合計(計税率1)
                dr[DCKAK02644EA.Col_TotalStckTtlAccPayBalanceTaxRate1] = accPaymentListResultWork.TotalStckTtlAccPayBalanceTaxRate1;
                // 当月合計(計税率2)
                dr[DCKAK02644EA.Col_TotalStckTtlAccPayBalanceTaxRate2] = accPaymentListResultWork.TotalStckTtlAccPayBalanceTaxRate2;
                // 当月合計(計その他)
                dr[DCKAK02644EA.Col_TotalStckTtlAccPayBalanceOther] = accPaymentListResultWork.TotalStckTtlAccPayBalanceOther;
                // 枚数(計税率1)
                dr[DCKAK02644EA.Col_TotalStockSlipCountTaxRate1] = accPaymentListResultWork.TotalStockSlipCountTaxRate1;
                // 枚数(計税率2)
                dr[DCKAK02644EA.Col_TotalStockSlipCountTaxRate2] = accPaymentListResultWork.TotalStockSlipCountTaxRate2;
                // 枚数(計その他)
                dr[DCKAK02644EA.Col_TotalStockSlipCountOther] = accPaymentListResultWork.TotalStockSlipCountOther;
                // 税率1タイトル
                dr[DCKAK02644EA.Col_TitleTaxRate1] = accPaymentListResultWork.TitleTaxRate1;
                // 税率2タイトル
                dr[DCKAK02644EA.Col_TitleTaxRate2] = accPaymentListResultWork.TitleTaxRate2;
                // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
                // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                // 仕入額(計非課税)
                dr[DCKAK02644EA.Col_TotalThisTimeStockPriceTaxFree] = accPaymentListResultWork.TotalThisTimeStockPriceTaxFree;
                // 返品値引(計非課税)
                dr[DCKAK02644EA.Col_TotalThisRgdsDisPricTaxFree] = accPaymentListResultWork.TotalThisRgdsDisPricTaxFree;
                // 純仕入額(計非課税)
                dr[DCKAK02644EA.Col_TotalPureStockTaxFree] = accPaymentListResultWork.TotalPureStockTaxFree;
                // 消費税(計非課税)
                dr[DCKAK02644EA.Col_TotalStockPricTaxTaxFree] = accPaymentListResultWork.TotalStockPricTaxTaxFree;
                // 当月合計(計非課税)
                dr[DCKAK02644EA.Col_TotalStckTtlAccPayBalanceTaxFree] = accPaymentListResultWork.TotalStckTtlAccPayBalanceTaxFree;
                // 枚数(計非課税)
                dr[DCKAK02644EA.Col_TotalStockSlipCountTaxFree] = accPaymentListResultWork.TotalStockSlipCountTaxFree;
                // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
                // TableにAdd
				accPaymentTable.Rows.Add( dr );
			}
		}
		#endregion

        /// <summary>
        /// 出力金額区分チェック
        /// </summary>
        /// <param name="accPaymentListCndtn">UI抽出条件クラス</param>
        /// <param name="accPaymentListResultWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 出力金額区分で今回支払額をチェックする。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>
        private bool CheckOutputMoneyDiv(AccPaymentListCndtn accPaymentListCndtn, AccPaymentListResultWork accPaymentListResultWork)
        {
            bool bRet = false;

            // 2009.02.10 30413 犬飼 仕入合計残高に修正 >>>>>>START
            //// 出力金額区分で今回支払額のチェック
            // 出力金額区分で仕入合計残高のチェック
            switch (accPaymentListCndtn.OutMoneyDiv)
            {
                case AccPaymentListCndtn.OutMoneyDivState.All: // 全て出力 
                    {
                        bRet = true;
                        break;
                    }
                case AccPaymentListCndtn.OutMoneyDivState.ZeroPlus: // ０とプラス金額を出力
                    {
                        //if (accPaymentListResultWork.ThisTimePayNrml >= 0)
                        if (accPaymentListResultWork.StckTtlAccPayBalance >= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case AccPaymentListCndtn.OutMoneyDivState.Plus: // プラス金額のみ出力
                    {
                        //if (accPaymentListResultWork.ThisTimePayNrml > 0)
                        if (accPaymentListResultWork.StckTtlAccPayBalance > 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case AccPaymentListCndtn.OutMoneyDivState.Zero: // ０のみ出力
                    {
                        //if (accPaymentListResultWork.ThisTimePayNrml == 0)
                        if (accPaymentListResultWork.StckTtlAccPayBalance == 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case AccPaymentListCndtn.OutMoneyDivState.PlusMinus: // プラス金額とマイナス金額を出力
                    {
                        //if (accPaymentListResultWork.ThisTimePayNrml != 0)
                        if (accPaymentListResultWork.StckTtlAccPayBalance != 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case AccPaymentListCndtn.OutMoneyDivState.ZeroMinus: // ０とマイナス金額を出力
                    {
                        //if (accPaymentListResultWork.ThisTimePayNrml <= 0)
                        if (accPaymentListResultWork.StckTtlAccPayBalance <= 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                case AccPaymentListCndtn.OutMoneyDivState.Minus: // マイナス金額のみ出力
                    {
                        //if (accPaymentListResultWork.ThisTimePayNrml < 0)
                        if (accPaymentListResultWork.StckTtlAccPayBalance < 0)
                        {
                            bRet = true;
                        }
                        break;
                    }
                default:
                    break;
            }
            // 2009.02.10 30413 犬飼 仕入合計残高に修正 <<<<<<END
            
            return bRet;
        }

        /// <summary>
        /// 月次締未更新チェック
        /// </summary>
        /// <param name="accPaymentListCndtn">UI抽出条件クラス</param>
        /// <param name="accPaymentListResultWork">抽出結果クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 拠点毎の月次締未更新チェックを行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.10</br>
        /// </remarks>
        private bool CheckMonAddUpNonProc(AccPaymentListCndtn accPaymentListCndtn, AccPaymentListResultWork accPaymentListResultWork)
        {
            bool retb = false;
            string key = accPaymentListResultWork.AddUpSecCode.TrimEnd();

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
                    if (prevTotalMonth < accPaymentListCndtn.AddUpYearMonth)
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
	    /// <br>Programmer : 22018 鈴木 正臣</br>
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
