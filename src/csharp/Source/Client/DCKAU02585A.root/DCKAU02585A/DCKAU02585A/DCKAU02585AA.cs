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
    /// 請求残高元帳アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求残高元帳で使用するデータを取得する。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.08</br>
    /// <br>Update Note: 2008/12/08 30414 忍 幸史 Partsman用に変更</br>
    /// </remarks>
	public class DmdBalanceAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 請求残高元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 請求残高元帳アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public DmdBalanceAcs()
		{
            this._iDemandBalanceLedgerDB = (IDemandBalanceLedgerDB)MediationDemandBalanceLedgerDB.GetDemandBalanceLedgerDB();
		}

		/// <summary>
        /// 請求残高元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 請求残高元帳アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.08</br>
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
        IDemandBalanceLedgerDB _iDemandBalanceLedgerDB;  

		private DataSet _dmdBalanceDs;				    // 残高元帳データセット

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
        /// <param name="extrInfo_DmdBalance">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 印刷する残高元帳データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.08</br>
		/// </remarks>
        public int SearchDmdBalance(ExtrInfo_DemandBalance extrInfo_DmdBalance, out string errMsg)
		{
            return this.SearchDmdBalanceProc(extrInfo_DmdBalance, out errMsg);
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
        /// <param name="extrInfo_DmdBalance"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.08</br>
		/// </remarks>
        private int SearchDmdBalanceProc(ExtrInfo_DemandBalance extrInfo_DmdBalance, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAU02584EA.CreateDataTableDmdBalanceMain(ref this._dmdBalanceDs);
                ExtrInfo_DemandBalanceWork extrInfo_DemandBalanceWork = new ExtrInfo_DemandBalanceWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevDmdBalance(extrInfo_DmdBalance, out extrInfo_DemandBalanceWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retDemandBalanceList = null;
                status = this._iDemandBalanceLedgerDB.SearchDemandBalanceLedger( out retDemandBalanceList, extrInfo_DemandBalanceWork );
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
                        DevDmdBalanceData(extrInfo_DmdBalance, this._dmdBalanceDs.Tables[DCKAU02584EA.Col_Tbl_DmdBalance], (ArrayList)retDemandBalanceList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "請求残高元帳データの取得に失敗しました。";
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
		/// <param name="extrInfo_DmdBalance">UI抽出条件クラス</param>
		/// <param name="extrInfo_DemandBalanceWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevDmdBalance(ExtrInfo_DemandBalance extrInfo_DmdBalance, out ExtrInfo_DemandBalanceWork extrInfo_DemandBalanceWork, out string errMsg)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            extrInfo_DemandBalanceWork = new ExtrInfo_DemandBalanceWork();

			try
			{
				extrInfo_DemandBalanceWork.EnterpriseCode = extrInfo_DmdBalance.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (extrInfo_DmdBalance.SectionCodes.Length != 0)
				{
					if ( extrInfo_DmdBalance.IsSelectAllSection )
					{
						// 全社の時
                        extrInfo_DemandBalanceWork.SectionCodes = null;
					}
					else
					{
                        extrInfo_DemandBalanceWork.SectionCodes = extrInfo_DmdBalance.SectionCodes;
					}
				}
				else
				{
                    extrInfo_DemandBalanceWork.SectionCodes = null;
				}

                extrInfo_DemandBalanceWork.St_AddUpYearMonth = extrInfo_DmdBalance.St_AddUpYearMonth;         // 開始対象年月
                extrInfo_DemandBalanceWork.Ed_AddUpYearMonth = extrInfo_DmdBalance.Ed_AddUpYearMonth;         // 終了対象年月
                // --- CHG 2008/12/08 --------------------------------------------------------------------->>>>>
                //extrInfo_DemandBalanceWork.St_ClaimCode = extrInfo_DmdBalance.St_CustomerCode;		          // 開始得意先コード
                //extrInfo_DemandBalanceWork.Ed_ClaimCode = extrInfo_DmdBalance.Ed_CustomerCode;		          // 終了得意先コード
                //extrInfo_DemandBalanceWork.OutMoneyDiv  = (int)extrInfo_DmdBalance.OutMoneyDiv;               // 出力金額区分 
                if (extrInfo_DmdBalance.St_ClaimCode == 0)
                {
                    extrInfo_DemandBalanceWork.St_ClaimCode = 1;
                }
                else
                {
                    extrInfo_DemandBalanceWork.St_ClaimCode = extrInfo_DmdBalance.St_ClaimCode;		          // 開始請求先コード
                }
                if (extrInfo_DmdBalance.Ed_ClaimCode == 0)
                {
                    extrInfo_DemandBalanceWork.Ed_ClaimCode = 99999999;
                }
                else
                {
                    extrInfo_DemandBalanceWork.Ed_ClaimCode = extrInfo_DmdBalance.Ed_ClaimCode;		          // 終了請求先コード
                }
                // --- CHG 2008/12/08 ---------------------------------------------------------------------<<<<<                
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
		/// <param name="extrInfo_DmdBalance">UI抽出条件クラス</param>
		/// <param name="dmdBalanceDt">展開対象DataTable</param>
        /// <param name="dmdBalanceWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.08</br>
		/// </remarks>
        private void DevDmdBalanceData(ExtrInfo_DemandBalance extrInfo_DmdBalance, DataTable dmdBalanceDt, ArrayList dmdBalanceWork)
		{
			DataRow dr;
            foreach (RsltInfo_DemandBalanceWork rsltInfo_DemandBalanceWork in dmdBalanceWork)
			{
                dr = dmdBalanceDt.NewRow();
			    
                // 計上拠点コード
                dr[DCKAU02584EA.Col_AddUpSecCode] = rsltInfo_DemandBalanceWork.AddUpSecCode;
				// 計上拠点名称
                //if ( extrInfo_DmdBalance.IsSelectAllSection)
                //    dr[DCKAU02584EA.Col_AddUpSecName] = "全社";
                //else
                dr[DCKAU02584EA.Col_AddUpSecName] = rsltInfo_DemandBalanceWork.AddUpSecName.TrimEnd();

                /* --- DEL 2008/12/08 --------------------------------------------------------------------->>>>>
				// 計上拠点名称(明細)
                dr[DCKAU02584EA.Col_AddUpSecName_Detail] = rsltInfo_DemandBalanceWork.AddUpSecName.TrimEnd();
                   --- DEL 2008/12/08 ---------------------------------------------------------------------<<<<<*/

                // 請求先コード
                dr[DCKAU02584EA.Col_ClaimCode] = rsltInfo_DemandBalanceWork.ClaimCode;
                
                /* --- DEL 2008/12/08 --------------------------------------------------------------------->>>>>
                // 請求先名称
                dr[DCKAU02584EA.Col_ClaimName] = rsltInfo_DemandBalanceWork.ClaimName;
                // 請求先名称2
                dr[DCKAU02584EA.Col_ClaimName2] = rsltInfo_DemandBalanceWork.ClaimName2;
                   --- DEL 2008/12/08 ---------------------------------------------------------------------<<<<<*/

                // 請求先略称
                dr[DCKAU02584EA.Col_ClaimSnm] = rsltInfo_DemandBalanceWork.ClaimSnm;
                // 計上日
                dr[DCKAU02584EA.Col_AddUpDate] = TDateTime.DateTimeToString(ExtrInfo_DemandBalance.ct_DateFomat, rsltInfo_DemandBalanceWork.AddUpDate);
                // 前回請求金額
                // --- CHG 2008/12/08 --------------------------------------------------------------------->>>>>
                //dr[DCKAU02584EA.Col_LastTimeDemand] = rsltInfo_DemandBalanceWork.LastTimeDemand;
                dr[DCKAU02584EA.Col_LastTimeDemand] = rsltInfo_DemandBalanceWork.AcpOdrTtl3TmBfBlDmd +
                                                      rsltInfo_DemandBalanceWork.AcpOdrTtl2TmBfBlDmd +
                                                      rsltInfo_DemandBalanceWork.LastTimeDemand;
                // --- CHG 2008/12/08 ---------------------------------------------------------------------<<<<<

                // 今回入金金額（通常入金）
                dr[DCKAU02584EA.Col_ThisTimeDmdNrml] = rsltInfo_DemandBalanceWork.ThisTimeDmdNrml;
                
                /* --- DEL 2008/12/08 --------------------------------------------------------------------->>>>>
                // 今回手数料額（通常入金）
                dr[DCKAU02584EA.Col_ThisTimeFeeDmdNrml] = rsltInfo_DemandBalanceWork.ThisTimeFeeDmdNrml;
                // 今回値引額（通常入金）
                dr[DCKAU02584EA.Col_ThisTimeDisDmdNrml] = rsltInfo_DemandBalanceWork.ThisTimeDisDmdNrml;
                   --- DEL 2008/12/08 ---------------------------------------------------------------------<<<<<*/

                // 今回繰越残高（請求計）
                dr[DCKAU02584EA.Col_ThisTimeTtlBlcDmd] = rsltInfo_DemandBalanceWork.ThisTimeTtlBlcDmd;
                
                // 純売上
                // --- CHG 2008/12/08 --------------------------------------------------------------------->>>>>
                //dr[DCKAU02584EA.Col_OfsThisTimeSales] = rsltInfo_DemandBalanceWork.OfsThisTimeSales;
                dr[DCKAU02584EA.Col_OfsThisTimeSales] = rsltInfo_DemandBalanceWork.ThisTimeSales +
                                                        rsltInfo_DemandBalanceWork.ThisSalesPricRgds +
                                                        rsltInfo_DemandBalanceWork.ThisSalesPricDis;
                // --- CHG 2008/12/08 ---------------------------------------------------------------------<<<<<

                // 相殺後今回売上消費税
                dr[DCKAU02584EA.Col_OfsThisSalesTax] = rsltInfo_DemandBalanceWork.OfsThisSalesTax;

                // 今回売上金額
                dr[DCKAU02584EA.Col_ThisTimeSales] = rsltInfo_DemandBalanceWork.ThisTimeSales;
                
                /* --- DEL 2008/12/08 --------------------------------------------------------------------->>>>>
                // 今回売上消費税
                dr[DCKAU02584EA.Col_ThisSalesTax] = rsltInfo_DemandBalanceWork.ThisSalesTax;
                // 今回売上返品金額
                dr[DCKAU02584EA.Col_ThisSalesPricRgds] = rsltInfo_DemandBalanceWork.ThisSalesPricRgds;
                // 今回売上返品金額
                dr[DCKAU02584EA.Col_ThisSalesPrcTaxRgds] = rsltInfo_DemandBalanceWork.ThisSalesPrcTaxRgds;
                // 今回売上値引金額
                dr[DCKAU02584EA.Col_ThisSalesPricDis] = rsltInfo_DemandBalanceWork.ThisSalesPricDis;
                // 今回売上値引消費税
                dr[DCKAU02584EA.Col_ThisSalesPrcTaxDis] = rsltInfo_DemandBalanceWork.ThisSalesPrcTaxDis;
                // 今回支払相殺金額
                dr[DCKAU02584EA.Col_ThisPayOffset] = rsltInfo_DemandBalanceWork.ThisPayOffset;
                // 今回支払相殺消費税
                dr[DCKAU02584EA.Col_ThisPayOffsetTax] = rsltInfo_DemandBalanceWork.ThisPayOffsetTax;
                // 残高調整額
                dr[DCKAU02584EA.Col_BalanceAdjust] = rsltInfo_DemandBalanceWork.BalanceAdjust;
                   --- DEL 2008/12/08 ---------------------------------------------------------------------<<<<<*/

                // 計算後請求金額
                dr[DCKAU02584EA.Col_AfCalDemandPrice] = rsltInfo_DemandBalanceWork.AfCalDemandPrice;
                // 売上伝票枚数
                dr[DCKAU02584EA.Col_SalesSlipCount] = rsltInfo_DemandBalanceWork.SalesSlipCount;
                
                /* --- DEL 2008/12/08 --------------------------------------------------------------------->>>>>
                // 入金予定日
                dr[DCKAU02584EA.Col_ExpectedDepositDate] = TDateTime.DateTimeToString(ExtrInfo_DemandBalance.ct_DateFomat, rsltInfo_DemandBalanceWork.ExpectedDepositDate);
                   --- DEL 2008/12/08 ---------------------------------------------------------------------<<<<<*/

                // 回収条件
                dr[DCKAU02584EA.Col_CollectCond] = GetCondName(rsltInfo_DemandBalanceWork.CollectCond);
                // 請求締日
                dr[DCKAU02584EA.Col_TotalDay] = rsltInfo_DemandBalanceWork.TotalDay;
                // 請求月区分名称
                dr[DCKAU02584EA.Col_CollectMoneyName] = rsltInfo_DemandBalanceWork.CollectMoneyName;
                // 請求日
                dr[DCKAU02584EA.Col_CollectMoneyDay] = rsltInfo_DemandBalanceWork.CollectMoneyDay;
                /* --- DEL 2008/12/08 --------------------------------------------------------------------->>>>>
                // 集金担当従業員コード
                dr[DCKAU02584EA.Col_BillCollecterCd] = rsltInfo_DemandBalanceWork.BillCollecterCd;
                   --- DEL 2008/12/08 ---------------------------------------------------------------------<<<<<*/
                // 集金担当従業員名称
                dr[DCKAU02584EA.Col_BillCollecterNm] = rsltInfo_DemandBalanceWork.BillCollecterNm;
                // 2009.02.09 30413 犬飼 返品・値引きの符号を反転 >>>>>>START
                // 返品・値引
                //dr[DCKAU02584EA.Col_RgdsDisT] = rsltInfo_DemandBalanceWork.ThisSalesPricRgds + rsltInfo_DemandBalanceWork.ThisSalesPricDis;
                dr[DCKAU02584EA.Col_RgdsDisT] = -(rsltInfo_DemandBalanceWork.ThisSalesPricRgds + rsltInfo_DemandBalanceWork.ThisSalesPricDis);
                // 2009.02.09 30413 犬飼 返品・値引きの符号を反転 <<<<<<END
                // 税込売上額
                // --- CHG 2008/12/08 --------------------------------------------------------------------->>>>>
                //dr[DCKAU02584EA.Col_ThisSalesTaxTotal] = rsltInfo_DemandBalanceWork.OfsThisTimeSales + rsltInfo_DemandBalanceWork.OfsThisSalesTax;
                dr[DCKAU02584EA.Col_ThisSalesTaxTotal] = rsltInfo_DemandBalanceWork.ThisTimeSales +
                                                        rsltInfo_DemandBalanceWork.ThisSalesPricRgds +
                                                        rsltInfo_DemandBalanceWork.ThisSalesPricDis +
                                                         rsltInfo_DemandBalanceWork.OfsThisSalesTax;
                // --- CHG 2008/12/08 ---------------------------------------------------------------------<<<<<
                // TableにAdd
				dmdBalanceDt.Rows.Add( dr );
			}
		}
		#endregion

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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.02</br>
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
	    /// <br>Date       : 2007.11.08</br>
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
