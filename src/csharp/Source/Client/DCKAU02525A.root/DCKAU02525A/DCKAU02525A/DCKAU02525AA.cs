//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 回収予定表
// プログラム概要   : 回収予定表の印字を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/11/17  修正内容 : PM.NS用に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/18  修正内容 : 不具合対応[13302]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/04/05  修正内容 : MANTIS[15251]の対応。（締日・回収日の末日指定修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gezh
// 作 成 日  2012/05/22  修正内容 : 2012/06/27配信分 Redmine#29880 回収予定表 得意先マスタの「得意先名」を印字できるようにするの対応
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
    /// 回収予定表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 回収予定表で使用するデータを取得する。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.10.23</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/05  22018 鈴木 正臣</br>
    /// <br>           : MANTIS[15251]の対応。（締日・回収日の末日指定修正）</br>
    /// <br></br>
    /// </remarks>
	public class CollectPlanAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 回収予定表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 回収予定表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.23</br>
		/// </remarks>
		public CollectPlanAcs()
		{
            this._iCollectProgramDB = (ICollectProgramDB)MediationCollectProgramDB.GetCollectProgramDB();

            this._moneyKindAcs = new MoneyKindAcs();		// 金種設定アクセスクラス

            // 2008.11.20 30413 犬飼 日付取得部品の追加 >>>>>>START
            //日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
            // 2008.11.20 30413 犬飼 日付取得部品の追加 <<<<<<END
		}

		/// <summary>
		/// 回収予定表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 回収予定表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.23</br>
		/// </remarks>
		static CollectPlanAcs()
		{
			stc_Employee		    = null;
			stc_PrtOutSet		    = null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	    = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_depositKindSortList = new SortedList();	// 入金金種リスト

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
		private static PrtOutSet stc_PrtOutSet;			    // 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	    // 帳票出力設定アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
        ICollectProgramDB _iCollectProgramDB;               // 回収予定表リモート

		private DataSet _collectPlanDs;				        // 回収予定表データセット
        // 2008.12.16 30413 犬飼 フィルター追加 >>>>>>START
        private DataView _collectPlanDv;
        // 2008.12.16 30413 犬飼 フィルター追加 <<<<<<END
        
        private MoneyKindAcs _moneyKindAcs;		// 金種設定アクセスクラス

        private static SortedList stc_depositKindSortList;	// 入金金種リスト

        // 2008.11.20 30413 犬飼 日付取得部品の追加 >>>>>>START
        // 日付取得部品
        private DateGetAcs _dateGetAcs;
        // 2008.11.20 30413 犬飼 日付取得部品の追加 <<<<<<END


		#endregion ■ Private Member

		#region ■ Public Property
        // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 >>>>>>START
        ///// <summary>
        ///// 回収予定表データセット(読み取り専用)
        ///// </summary>
        //public DataSet CollectPlanDs
        //{
        //    get{ return this._collectPlanDs; }
        //}
        /// <summary>
		/// 回収予定表データビュー(読み取り専用)
		/// </summary>
        public DataView CollectPlanDv
        {
            get { return this._collectPlanDv; }
        }
        // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 <<<<<<END
        #endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 請求データ取得
		/// <summary>
		/// 回収予定表データ取得
		/// </summary>
		/// <param name="rsltInfo_CollectPlan">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する回収予定表データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.23</br>
		/// </remarks>
        public int SearchCollectPlan(RsltInfo_CollectPlan rsltInfo_CollectPlan, out string errMsg)
		{
            return this.SearchCollectPlanProc(rsltInfo_CollectPlan, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 回収予定表データ取得
		/// <summary>
		/// 回収予定表データ取得
		/// </summary>
        /// <param name="rsltInfo_CollectPlan"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する回収予定表データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.23</br>
		/// </remarks>
        private int SearchCollectPlanProc(RsltInfo_CollectPlan rsltInfo_CollectPlan, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAU02524EA.CreateDataTableCollectPlanMain(ref this._collectPlanDs);
                ExtrInfo_CollectPlanWork extrInfo_CollectPlanWork = new ExtrInfo_CollectPlanWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevCollectPlan(rsltInfo_CollectPlan, out extrInfo_CollectPlanWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retCollectPlanList = null;
                status = this._iCollectProgramDB.SearchCollectProgram(out retCollectPlanList, extrInfo_CollectPlanWork);
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
                        DevCollectPlanData(rsltInfo_CollectPlan, this._collectPlanDs.Tables[DCKAU02524EA.Col_Tbl_RsltInfo_CollectPlan], (ArrayList)retCollectPlanList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        // 2008.12.16 30413 犬飼 フィルターを追加 >>>>>>START
                        if (this._collectPlanDv.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // 2008.12.16 30413 犬飼 フィルターを追加 <<<<<<END

						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "回収予定表データの取得に失敗しました。";
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
		/// <param name="rsltInfo_CollectPlan">UI抽出条件クラス</param>
		/// <param name="extrInfo_CollectPlanWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevCollectPlan(RsltInfo_CollectPlan rsltInfo_CollectPlan, out ExtrInfo_CollectPlanWork extrInfo_CollectPlanWork, out string errMsg)
		{
                                                                               
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			errMsg = string.Empty;
            extrInfo_CollectPlanWork = new ExtrInfo_CollectPlanWork();
 
			try
			{
                // 企業コード
				extrInfo_CollectPlanWork.EnterpriseCode = rsltInfo_CollectPlan.EnterpriseCode;

				// 抽出条件パラメータセット
                if (rsltInfo_CollectPlan.CollectAddupSecCodeList.Length != 0)
				{
					if ( rsltInfo_CollectPlan.IsSelectAllSection )
					{
						// 全社の時
                        extrInfo_CollectPlanWork.CollectAddupSecCodeList = null;
					}
					else
					{
                        extrInfo_CollectPlanWork.CollectAddupSecCodeList = rsltInfo_CollectPlan.CollectAddupSecCodeList;
					}
				}
				else
				{
                    extrInfo_CollectPlanWork.CollectAddupSecCodeList = null;
				}

                extrInfo_CollectPlanWork.AddUpDate    = rsltInfo_CollectPlan.AddUpDate;	                             // 処理日
                extrInfo_CollectPlanWork.SortOrderDiv = (int)rsltInfo_CollectPlan.SortOrderDiv;                      // 出力順
                
                // --- UPD m.suzuki 2010/04/05 ---------->>>>>
                //// 2008.11.13 30413 犬飼 締日の設定を変更 >>>>>>START
                ////extrInfo_CollectPlanWork.TotalDay     = (int)rsltInfo_CollectPlan.TotalDay;                          // 締日
                //if (rsltInfo_CollectPlan.TotalDay < 28)
                //{
                //    // 28日より前
                //    extrInfo_CollectPlanWork.TotalDay = (int)rsltInfo_CollectPlan.TotalDay;                          // 締日
                //}
                //else
                //{
                //    // 28日以降
                //    extrInfo_CollectPlanWork.TotalDay = 99;
                //}
                //// 2008.11.13 30413 犬飼 締日の設定を変更 <<<<<<END

                // 締日
                extrInfo_CollectPlanWork.TotalDay = (int)rsltInfo_CollectPlan.TotalDay;
                // 締日末日指定（28以降は末日指定とみなす）
                extrInfo_CollectPlanWork.IsLastDayTotalDay = ( rsltInfo_CollectPlan.TotalDay >= 28 );
                // --- UPD m.suzuki 2010/04/05 ----------<<<<<

                extrInfo_CollectPlanWork.St_ClaimCode = rsltInfo_CollectPlan.St_ClaimCode;		                     // 開始得意先コード
                extrInfo_CollectPlanWork.Ed_ClaimCode = rsltInfo_CollectPlan.Ed_ClaimCode;		                     // 終了得意先コード
                extrInfo_CollectPlanWork.EmployeeKindDiv = (int)rsltInfo_CollectPlan.EmployeeKindDiv;                // 担当者区分
				extrInfo_CollectPlanWork.St_EmployeeCode = rsltInfo_CollectPlan.St_EmployeeCode;		             // 開始担当者コード
				extrInfo_CollectPlanWork.Ed_EmployeeCode = rsltInfo_CollectPlan.Ed_EmployeeCode;		             // 終了担当者コード
                extrInfo_CollectPlanWork.St_SalesAreaCode = rsltInfo_CollectPlan.St_SalesAreaCode;		             // 開始地区コード
                extrInfo_CollectPlanWork.Ed_SalesAreaCode = rsltInfo_CollectPlan.Ed_SalesAreaCode;		             // 終了地区コード

                // --- UPD m.suzuki 2010/04/05 ---------->>>>>
                //// 2008.11.13 30413 犬飼 回収予定日の設定を変更 >>>>>>START
                ////extrInfo_CollectPlanWork.CollectSchedule = (int)rsltInfo_CollectPlan.ExpectedDepositDate;            // 回収予定日
                //if (rsltInfo_CollectPlan.ExpectedDepositDate < 28)
                //{
                //    // 28日より前
                //    extrInfo_CollectPlanWork.CollectSchedule = (int)rsltInfo_CollectPlan.ExpectedDepositDate;            // 回収予定日
                //}
                //else
                //{
                //    // 28日以降
                //    extrInfo_CollectPlanWork.CollectSchedule = 99;
                //}
                //// 2008.11.13 30413 犬飼 回収予定日の設定を変更 <<<<<<END

                // 回収予定日
                extrInfo_CollectPlanWork.CollectSchedule = (int)rsltInfo_CollectPlan.ExpectedDepositDate;
                // 回収予定日末日指定（28以降は末日指定とみなす）
                extrInfo_CollectPlanWork.IsLastDayCollectSchedule = (rsltInfo_CollectPlan.ExpectedDepositDate >= 28);
                // --- UPD m.suzuki 2010/04/05 ----------<<<<<

                // --- DEL m.suzuki 2010/04/05 ---------->>>>>
                //extrInfo_CollectPlanWork.IsLastDayTotalDay = rsltInfo_CollectPlan.IsLastDayTotalDay;                 // 締日末日
                //extrInfo_CollectPlanWork.IsLastDayCollectSchedule = rsltInfo_CollectPlan.IsLastDayCollectSchedule;   // 回収予定日末日
                // --- DEL m.suzuki 2010/04/05 ----------<<<<<

                Hashtable _collectCondDivList = new Hashtable();
                foreach (Int32 wk in rsltInfo_CollectPlan.CollectCond.Keys)
                {
                    _collectCondDivList.Add(wk, wk);
                }
                extrInfo_CollectPlanWork.CollectCond = (Int32[])new ArrayList(_collectCondDivList.Values).ToArray(typeof(Int32)); // 回収条件 

                if (extrInfo_CollectPlanWork.CollectCond[0] == -1)
                {
                    extrInfo_CollectPlanWork.CollectCond = null;
                }
			}                                              
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

		private int GetSortOrder( int sumDiv, int sortOrderDiv )
		{
			return sumDiv * 10 + sortOrderDiv;
		}
		#endregion

		#region ◎ 回収予定表データ展開処理
		/// <summary>
		/// 回収予定表データ展開処理
		/// </summary>
		/// <param name="rsltInfo_CollectPlan">UI抽出条件クラス</param>
		/// <param name="collectPlanDt">展開対象DataTable</param>
		/// <param name="collectPlanWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 回収予定表データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.10.23</br>
		/// </remarks>
        private void DevCollectPlanData(RsltInfo_CollectPlan rsltInfo_CollectPlan, DataTable collectPlanDt, ArrayList collectPlanWork)
		{
			DataRow dr;
            foreach (RsltInfo_CollectPlanWork rsltInfo_CollectPlanWork in collectPlanWork)
			{
                dr = collectPlanDt.NewRow();
                
                // 2008.11.11 30413 犬飼 抽出結果の展開項目を変更 >>>>>>START
                // 回収予定表データ展開
                #region 回収予定表データ展開
				// 計上拠点コード
                dr[DCKAU02524EA.Col_AddUpSecCode] = rsltInfo_CollectPlanWork.AddUpSecCode;
                // 計上拠点名称
				dr[DCKAU02524EA.Col_AddUpSecName] = rsltInfo_CollectPlanWork.AddUpSecName.TrimEnd();
				// 計上拠点名称(明細)
				dr[DCKAU02524EA.Col_AddUpSecName_Detail] = rsltInfo_CollectPlanWork.AddUpSecName.TrimEnd();
		        // 請求先コード
                dr[DCKAU02524EA.Col_ClaimCode] = rsltInfo_CollectPlanWork.ClaimCode;
                // 請求先名称
                dr[DCKAU02524EA.Col_ClaimName] = rsltInfo_CollectPlanWork.ClaimName;
                // 請求先名称2
                dr[DCKAU02524EA.Col_ClaimName2] = rsltInfo_CollectPlanWork.ClaimName2;
                // 請求先略称
                //dr[DCKAU02524EA.Col_ClaimSnm] = rsltInfo_CollectPlanWork.ClaimSnm;  // DEL 2012/05/22 gezh Redmine#29880
                // ADD 2012/05/22 gezh Redmine#29880 --------------------------------->>>>>
                if (rsltInfo_CollectPlan.CustomerNamePrint == 0)
                {
                    dr[DCKAU02524EA.Col_ClaimSnm] = rsltInfo_CollectPlanWork.ClaimSnm;
                }
                else
                {
                    dr[DCKAU02524EA.Col_ClaimSnm] = nameJoin(rsltInfo_CollectPlanWork.ClaimName, rsltInfo_CollectPlanWork.ClaimName2);
                }
                // ADD 2012/05/22 gezh Redmine#29880 ---------------------------------<<<<<
                // 計上年月日
                dr[DCKAU02524EA.Col_AddUpDate] = TDateTime.DateTimeToString(RsltInfo_CollectPlan.ct_DateFomat, rsltInfo_CollectPlanWork.AddUpDate);
                // 計上年月日(ソート用)
                dr[DCKAU02524EA.Col_Sort_AddUpDate] = TDateTime.DateTimeToLongDate(rsltInfo_CollectPlanWork.AddUpDate);
                // 計上年月
                dr[DCKAU02524EA.Col_AddUpYearMonth] = TDateTime.DateTimeToString(RsltInfo_CollectPlan.ct_MonthFomat, rsltInfo_CollectPlanWork.AddUpYearMonth);
                // 計上年月(ソート用)
                dr[DCKAU02524EA.Col_Sort_AddUpYearMonth] = TDateTime.DateTimeToLongDate(rsltInfo_CollectPlanWork.AddUpYearMonth);
                // 前回請求金額
                dr[DCKAU02524EA.Col_LastTimeDemand] = rsltInfo_CollectPlanWork.LastTimeDemand;
                //// 今回手数料額（通常入金）
                //dr[DCKAU02524EA.Col_ThisTimeFeeDmdNrml] = rsltInfo_CollectPlanWork.ThisTimeFeeDmdNrml;
                //// 今回値引額（通常入金）
                //dr[DCKAU02524EA.Col_ThisTimeDisDmdNrml] = rsltInfo_CollectPlanWork.ThisTimeDisDmdNrml;
                // 今回入金金額（通常入金）
                dr[DCKAU02524EA.Col_ThisTimeDmdNrml] = rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                //// 今回繰越残高（請求計）
                //dr[DCKAU02524EA.Col_ThisTimeTtlBlcDmd] = rsltInfo_CollectPlanWork.ThisTimeTtlBlcDmd;
                // 相殺後今回売上金額 + 相殺後今回売上消費税 
                dr[DCKAU02524EA.Col_OfsThisTimeSales] = rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax;
                // 相殺後今回売上消費税
                dr[DCKAU02524EA.Col_OfsThisSalesTax] = rsltInfo_CollectPlanWork.OfsThisSalesTax;
                //// 消費税調整額
                //dr[DCKAU02524EA.Col_TaxAdjust] = rsltInfo_CollectPlanWork.TaxAdjust;
                //// 残高調整額
                //dr[DCKAU02524EA.Col_BalanceAdjust] = rsltInfo_CollectPlanWork.BalanceAdjust;
                //// 計算後請求金額（今回分の請求金額）
                //dr[DCKAU02524EA.Col_AfCalDemandPrice] = rsltInfo_CollectPlanWork.AfCalDemandPrice;
                // 受注2回前残高（請求計）
                dr[DCKAU02524EA.Col_AcpOdrTtl2TmBfBlDmd] = rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd;
                // 受注3回前残高（請求計）
                dr[DCKAU02524EA.Col_AcpOdrTtl3TmBfBlDmd] = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd;
                //// 入金予定日
                //dr[DCKAU02524EA.Col_ExpectedDepositDate] = TDateTime.DateTimeToString(RsltInfo_CollectPlan.ct_DateFomat, rsltInfo_CollectPlanWork.ExpectedDepositDate);

                // 2008.11.21 30413 犬飼 回収条件の名称は別に設定 >>>>>>START
                //// 回収条件
                //dr[DCKAU02524EA.Col_CollectCond] = GetCollectCondName(rsltInfo_CollectPlanWork.CollectCond);
                // 回収条件
                dr[DCKAU02524EA.Col_CollectCond] = rsltInfo_CollectPlanWork.CollectCond.ToString();
                // 回収条件名称
                dr[DCKAU02524EA.Col_CollectCondName] = GetCollectCondName(rsltInfo_CollectPlanWork.CollectCond);
                // 2008.11.21 30413 犬飼 回収条件の名称は別に設定 <<<<<<END
                
                // 回収サイト
                dr[DCKAU02524EA.Col_CollectSight] = rsltInfo_CollectPlanWork.CollectSight;
                // 担当者コード
                dr[DCKAU02524EA.Col_BillCollecterCd] = rsltInfo_CollectPlanWork.BillCollecterCd;
                // 担当者名称
                dr[DCKAU02524EA.Col_BillCollecterNm] = rsltInfo_CollectPlanWork.BillCollecterNm;
                // 顧客担当従業員コード
                dr[DCKAU02524EA.Col_CustomerAgentCd] = rsltInfo_CollectPlanWork.CustomerAgentCd;
                // 顧客担当従業員名称
                dr[DCKAU02524EA.Col_CustomerAgentNm] = rsltInfo_CollectPlanWork.CustomerAgentNm;
                // 販売エリアコード
                dr[DCKAU02524EA.Col_SalesAreaCode] = rsltInfo_CollectPlanWork.SalesAreaCode;
                // 販売エリア名称
                dr[DCKAU02524EA.Col_SalesAreaName] = rsltInfo_CollectPlanWork.SalesAreaName;
                //// 回収対象
                //dr[DCKAU02524EA.Col_CollectTarget] = rsltInfo_CollectPlanWork.CollectTarget;
                // 締後入金額
                dr[DCKAU02524EA.Col_AfterCloseDemand] = rsltInfo_CollectPlanWork.AfterCloseDemand;
                //// 回収実績(集金日以降に入金した金額を集計) 
                //dr[DCKAU02524EA.Col_AfterScheduleDemand] = rsltInfo_CollectPlanWork.AfterScheduleDemand;
                // 算出項目↓

                // 2009.01.15 30413 犬飼 今回売上額の仕様変更 >>>>>>START
                // 今回売上額を計算(相殺後今回売上金額 + 相殺後今回売上消費税 + 今回売上返品金額 + 今回売上値引金額)
                //long calcThisTimeSales = rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax +
                //                         rsltInfo_CollectPlanWork.ThisSalesPricRgds + rsltInfo_CollectPlanWork.ThisSalesPricDis;
                // 今回売上額を計算(相殺後今回売上金額 + 相殺後今回売上消費税)
                long calcThisTimeSales = rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax;
                // 2009.01.15 30413 犬飼 今回売上額の仕様変更 <<<<<<END
                
                // 残高合計
                //dr[DCKAU02524EA.Col_TotalAdjust] = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand +
                //                                   rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                dr[DCKAU02524EA.Col_TotalAdjust] = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand +
                                                   calcThisTimeSales - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                //// 予定額
                //dr[DCKAU02524EA.Col_TotalExpct] = rsltInfo_CollectPlanWork.CollectTarget - rsltInfo_CollectPlanWork.AfterCloseDemand;
                //// 回収率
                //if (rsltInfo_CollectPlanWork.AfterCloseDemand != 0)
                //{
                //    dr[DCKAU02524EA.Col_CollectRate] = (rsltInfo_CollectPlanWork.AfterCloseDemand * 100) / (rsltInfo_CollectPlanWork.CollectTarget - rsltInfo_CollectPlanWork.AfterCloseDemand);
                //}
                dr[DCKAU02524EA.Col_CollectRate] = 0;
                //// 未回収額
                //dr[DCKAU02524EA.Col_NonCollect] = (rsltInfo_CollectPlanWork.CollectTarget - rsltInfo_CollectPlanWork.AfterCloseDemand) - rsltInfo_CollectPlanWork.AfterScheduleDemand;
				#endregion

                // 追加分
                // 今回売上返品金額
                dr[DCKAU02524EA.Col_ThisSalesPricRgds] = rsltInfo_CollectPlanWork.ThisSalesPricRgds;

                // 今回売上値引金額
                dr[DCKAU02524EA.Col_ThisSalesPricDis] = rsltInfo_CollectPlanWork.ThisSalesPricDis;

                // 集金月区分コード
                dr[DCKAU02524EA.Col_CollectMoneyCode] = rsltInfo_CollectPlanWork.CollectMoneyCode;

                // 集金月区分名称
                dr[DCKAU02524EA.Col_CollectMoneyName] = rsltInfo_CollectPlanWork.CollectMoneyName;

                // 集金日
                dr[DCKAU02524EA.Col_CollectMoneyDay] = rsltInfo_CollectPlanWork.CollectMoneyDay;

                // 回収予定区分
                dr[DCKAU02524EA.Col_CollectPlnDiv] = rsltInfo_CollectPlanWork.CollectPlnDiv;

                // 今回売上額(計算用)
                dr[DCKAU02524EA.Col_CalcThisTimeSales] = calcThisTimeSales;

                // 2009.01.15 30413 犬飼 締後回収日(集金日)の仕様変更 >>>>>>START
                // 締後回収日
                //DateTime calcCollectDay = rsltInfo_CollectPlanWork.AddUpDate.AddMonths(rsltInfo_CollectPlanWork.CollectMoneyCode);
                //double setDays = 0.0;
                //int endDays = DateTime.DaysInMonth(calcCollectDay.Year, calcCollectDay.Month);
                //if (rsltInfo_CollectPlanWork.CollectMoneyDay > endDays)
                //{
                //    // 集金日が締後回収日の月末を超えている
                //    setDays = endDays - (double)calcCollectDay.Day;
                //}
                //else
                //{
                //    // 集金日が締後回収日の月末を超えていない
                //    setDays = (double)rsltInfo_CollectPlanWork.CollectMoneyDay - (double)calcCollectDay.Day;
                //}
                //calcCollectDay = calcCollectDay.AddDays(setDays);
                //if (rsltInfo_CollectPlan.AddUpDate > calcCollectDay)
                //{
                //    // 処理日＞締後回収日の場合は翌月とする
                //    calcCollectDay = calcCollectDay.AddMonths(1);
                //}
                //dr[DCKAU02524EA.Col_CalcCollectDay] = TDateTime.DateTimeToString("YY/MM/DD", calcCollectDay);

                DateTime calcCollectDay = rsltInfo_CollectPlan.AddUpDate;
                double setDays = 0.0;
                if (rsltInfo_CollectPlanWork.CollectMoneyDay < rsltInfo_CollectPlan.AddUpDate.Day)
                {
                    // 得意先の集金日を超えている場合は翌月とする
                    calcCollectDay = calcCollectDay.AddMonths(1);
                }
                int endDays = DateTime.DaysInMonth(calcCollectDay.Year, calcCollectDay.Month);
                if (endDays < rsltInfo_CollectPlanWork.CollectMoneyDay)
                {
                    // 集金日が締後回収日の月末を超えている
                    setDays = endDays - (double)calcCollectDay.Day;
                }
                else
                {
                    // 集金日が締後回収日の月末を超えていない
                    setDays = rsltInfo_CollectPlanWork.CollectMoneyDay - (double)calcCollectDay.Day;
                }
                calcCollectDay = calcCollectDay.AddDays(setDays);
                dr[DCKAU02524EA.Col_CalcCollectDay] = TDateTime.DateTimeToString("YY/MM/DD", calcCollectDay);
                // 2009.01.15 30413 犬飼 締後回収日(集金日)の仕様変更 <<<<<<END
                
                // 対象額(計算用)
                long calcObjPric = 0;
                if (rsltInfo_CollectPlanWork.CollectPlnDiv == 0)
                {
                    // 回収予定区分が区分
                    // 2009.03.23 30413 犬飼 集金月の補正処理を追加 >>>>>>START
                    // 補正後集金月の取得
                    int correctCollectMoneyCode = CorrectCollectMoneyCode(rsltInfo_CollectPlanWork);

                    //if (rsltInfo_CollectPlanWork.CollectMoneyCode == 0)
                    if (correctCollectMoneyCode == 0)
                    {
                        // 当月(受注3回前残高+受注2回前残高+前回請求残高+相殺後今回売上額+相殺後今回売上消費税-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand +
                                      rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    //else if (rsltInfo_CollectPlanWork.CollectMoneyCode == 1)
                    else if (correctCollectMoneyCode == 1)
                    {
                        // 翌月(受注3回前残高+受注2回前残高+前回請求残高-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand -
                                      rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    //else if (rsltInfo_CollectPlanWork.CollectMoneyCode == 2)
                    else if (correctCollectMoneyCode == 2)
                    {
                        // 翌々月(受注3回前残高+受注2回前残高-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    //else if (rsltInfo_CollectPlanWork.CollectMoneyCode == 3)
                    else if (correctCollectMoneyCode == 3)
                    {
                        // 翌々々月(受注3回前残高-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    // 2009.03.23 30413 犬飼 集金月の補正処理を追加 <<<<<<END
                }
                else
                {
                    // 回収予定区分が日付
                    // 2009.02.20 30413 犬飼 締後回収日の算定と集金月の判定を修正 >>>>>>START
                    // 締後回収日の算定
                    DateTime calcDate = CalcDate(rsltInfo_CollectPlanWork);
                    // 経過期間の算出
                    DateTime progreTerm = rsltInfo_CollectPlan.AddUpDate;   // 処理日

                    // 集金月の判定
                    //if ((calcCollectDay < progreTerm) || (calcCollectDay < progreTerm.AddMonths(1)))
                    // 2009.03.23 30413 犬飼 締後回収月＜1か月後の場合は、マークを印字しないように修正 >>>>>>START
                    //if ((calcDate < progreTerm) || (calcDate < progreTerm.AddMonths(1)))
                    if (calcDate < progreTerm)
                    {
                        // 当月(受注3回前残高+受注2回前残高+前回請求残高+相殺後今回売上額+相殺後今回売上消費税-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand +
                                      rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                        // マーク
                        dr[DCKAU02524EA.Col_CollectMark] = "*";
                    }
                    else if (calcDate < progreTerm.AddMonths(1))
                    {
                        // 当月(受注3回前残高+受注2回前残高+前回請求残高+相殺後今回売上額+相殺後今回売上消費税-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand +
                                      rsltInfo_CollectPlanWork.OfsThisTimeSales + rsltInfo_CollectPlanWork.OfsThisSalesTax - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    // 2009.03.23 30413 犬飼 締後回収月＜1か月後の場合は、マークを印字しないように修正 <<<<<<END
                    //else if (calcCollectDay < progreTerm.AddMonths(2))
                    else if (calcDate < progreTerm.AddMonths(2))
                    {
                        // 翌月(受注3回前残高+受注2回前残高+前回請求残高-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_CollectPlanWork.LastTimeDemand -
                                      rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    //else if (calcCollectDay < progreTerm.AddMonths(3))
                    else if (calcDate < progreTerm.AddMonths(3))
                    {
                        // 翌々月(受注3回前残高+受注2回前残高-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_CollectPlanWork.AcpOdrTtl2TmBfBlDmd - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    else
                    {
                        // 翌々々月(受注3回前残高-今回入金額)
                        calcObjPric = rsltInfo_CollectPlanWork.AcpOdrTtl3TmBfBlDmd - rsltInfo_CollectPlanWork.ThisTimeDmdNrml;
                    }
                    // 2009.02.20 30413 犬飼 締後回収日の算定と集金月の判定を修正 <<<<<<END
                }
                dr[DCKAU02524EA.Col_CalcObjPric] = calcObjPric;

                // 予定額
                dr[DCKAU02524EA.Col_TotalExpct] = calcObjPric - rsltInfo_CollectPlanWork.AfterCloseDemand;

                // 地区コード(印刷用)
                if (rsltInfo_CollectPlanWork.SalesAreaCode == 0)
                {
                    dr[DCKAU02524EA.Col_SalesAreaCodePrint] = "";
                }
                else
                {
                    dr[DCKAU02524EA.Col_SalesAreaCodePrint] = rsltInfo_CollectPlanWork.SalesAreaCode;
                }
                // 2008.11.11 30413 犬飼 抽出結果の展開項目を変更 <<<<<<END

                // --- ADD 2009/03/09 障害ID:10843対応------------------------------------------------------>>>>>
                // 予定額＜0は印字しない
                if (rsltInfo_CollectPlan.PrintExpctDiv == 1)
                {
                    if ((Int64)dr[DCKAU02524EA.Col_TotalExpct] < 0)
                    {
                        continue;
                    }
                }
                // --- ADD 2009/03/09 障害ID:10843対応------------------------------------------------------<<<<<

				// TableにAdd
				collectPlanDt.Rows.Add( dr );
			}

            // 2008.12.16 30413 犬飼 フィルター処理を追加 >>>>>>START
            this._collectPlanDv = new DataView(collectPlanDt, GetRowFilter(), "", DataViewRowState.CurrentRows);
            // 2008.12.16 30413 犬飼 フィルター処理を追加 <<<<<<END
        }
		#endregion

        #region 
        /// <summary>
        /// 締後回収日の算定
        /// </summary>
        /// <returns>締後回収日</returns>
        private DateTime CalcDate(RsltInfo_CollectPlanWork rsltInfo_CollectPlanWork)
        {
            DateTime calcDate = rsltInfo_CollectPlanWork.AddUpDate.AddMonths(rsltInfo_CollectPlanWork.CollectMoneyCode);
            double setDays = 0.0;
            // 2009.03.23 30413 犬飼 締後回収日の算定の修正 >>>>>>START
            //if (rsltInfo_CollectPlanWork.CollectMoneyDay < calcDate.Day)
            //{
            //    // 得意先の集金日を超えている場合は翌月とする
            //    calcDate = calcDate.AddMonths(1);
            //}
            // 2009.03.23 30413 犬飼 締後回収日の算定の修正 <<<<<<END
            int endDays = DateTime.DaysInMonth(calcDate.Year, calcDate.Month);
            if (endDays < rsltInfo_CollectPlanWork.CollectMoneyDay)
            {
                // 集金日が締後回収日の月末を超えている
                setDays = endDays - (double)calcDate.Day;
            }
            else
            {
                // 集金日が締後回収日の月末を超えていない
                setDays = rsltInfo_CollectPlanWork.CollectMoneyDay - (double)calcDate.Day;
            }
            return calcDate.AddDays(setDays);
        }
        #endregion

        #region
        /// <summary>
        /// 集金月の補正
        /// </summary>
        /// <returns>補正後集金月</returns>
        private int CorrectCollectMoneyCode(RsltInfo_CollectPlanWork rsltInfo_CollectPlanWork)
        {
            // 集金月
            int collectMoneyCode = rsltInfo_CollectPlanWork.CollectMoneyCode;

            if (collectMoneyCode >= 1)
            {
                // 集金月が翌月以降
                //if (rsltInfo_CollectPlanWork.AddUpDate.Day >= rsltInfo_CollectPlanWork.CollectMoneyDay)   // DEL 2009/05/18
                if (rsltInfo_CollectPlanWork.TotalDay >= rsltInfo_CollectPlanWork.CollectMoneyDay)          // ADD 2009/05/18
                {
                    // 得意先マスタの締日≧集金日の場合は、集金月を補正
                    collectMoneyCode -= 1;
                }
            }
            
            return collectMoneyCode;
        }
        #endregion

        #region ◎ フィルター作成
        /// <summary>
        /// フィルター作成
        /// </summary>
        /// <returns>フィルター文字列</returns>
        private string GetRowFilter()
        {
            string filter = "";

            // 予定額
            filter = String.Format("{0} <> 0", DCKAU02524EA.Col_TotalExpct);

            return filter;
        }
        #endregion

		#endregion ◆ データ展開処理

        #region ◆ 固定項目名称設定
        #region ◎ 回収区分名称取得
        /// <summary>
        /// 回収区分名称取得
        /// </summary>
        /// <param name="collectCondCd">回収区分コード</param>
        /// <remarks>
        /// <br>Note       : 回収区分名称を取得する。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.23</br>
        /// </remarks>
        private string GetCollectCondName(int collectCondCd)
        {
            string pCName = "";
            
            // 名称をセット
            switch (collectCondCd)
            {
                // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 >>>>>>START
                //case 10:
                //    pCName = "現金";
                //    break;
                //case 20:
                //    pCName = "振込";
                //    break;
                //case 30:
                //    pCName = "小切手";
                //    break;
                //case 40:
                //    pCName = "手形";
                //    break;
                //case 50:
                //    pCName = "手数料";
                //    break;
                //case 60:
                //    pCName = "相殺";
                //    break;
                //case 70:
                //    pCName = "値引";
                //    break;
                //default:
                //    pCName = "その他";
                //    break;
                case (int)RsltInfo_CollectPlan.CollectCondDivState.Cash:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_Cash;
                    break;
                case (int)RsltInfo_CollectPlan.CollectCondDivState.Remittance:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_Remittance;
                    break;
                case (int)RsltInfo_CollectPlan.CollectCondDivState.Check:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_Check;
                    break;
                case (int)RsltInfo_CollectPlan.CollectCondDivState.Bill:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_Bill;
                    break;
                case (int)RsltInfo_CollectPlan.CollectCondDivState.Offset:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_Offset;
                    break;
                case (int)RsltInfo_CollectPlan.CollectCondDivState.FundTransfer:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_FundTransfer;
                    break;
                default:
                    pCName = RsltInfo_CollectPlan.ct_CollectCondDiv_Others;
                    break;
                // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 <<<<<<END
            }
            return (pCName);
        }
        #endregion

        #endregion ◆ 固定項目取得

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
	    /// <br>Date       : 2007.10.23</br>
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

        #region ◎ 金種設定取得
        /// <summary>
        /// 金種設定取得処理
        /// </summary>
        /// <param name="priceStCode">金額設定区分</param>
        /// <param name="retList"></param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 金種設定を取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public int SearchMoneyKind(int priceStCode, out SortedList retList, out string errMsg)
        {
            return this.SearchMoneyKindProc(priceStCode, out retList, out errMsg);
        }
        #endregion

        // ADD 2012/05/22 gezh Redmine#29880 --------------------------------->>>>>
        #region ◎ 名称１と名称２を結合
        /// <summary>
        /// 名称１と名称２を結合します。
        /// </summary>
        /// <param name="name1">名称１</param>
        /// <param name="name2">名称２</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 名称１と名称２の結合を取得する。</br>
        /// <br>Programmer : gezh</br>
        /// <br>Date       : 2012.05.22</br> 
        /// </remarks>
        private string nameJoin(string name1, string name2)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int count = sjisEnc.GetByteCount(name1);
            int spaceCount = 0;
            string n1 = "";
            string n2 = "";
            if (count <= 20)
            {
                spaceCount = 20 - count;
                if (sjisEnc.GetByteCount(name2) > 20)
                {
                    n2 = name2.Substring(0, 10);
                }
                else
                {
                    n2 = name2;
                }
                n1 = name1;
                for (; spaceCount > 0; spaceCount--)
                {
                    n1 = n1 + " ";
                }
                return n1 + n2;
            }
            else if (count < 40)
            {
                if (sjisEnc.GetByteCount(name2) > 40 - count)
                {
                    n2 = name2.Substring(0, (40 - count) / 2);
                }
                else
                {
                    n2 = name2;
                }
                return name1 + n2;
            }
            else
            {
                return name1;
            }
        }
        #endregion
        // ADD 2012/05/22 gezh Redmine#29880 ---------------------------------<<<<<

        #region ◎ 金種設定取得
        /// <summary>
        /// 金種設定取得処理
        /// </summary>
        /// <param name="priceStCode">金額設定区分</param>
        /// <param name="retList"></param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        private int SearchMoneyKindProc(int priceStCode, out SortedList retList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            retList = new SortedList();

            ArrayList workList = null;
            try
            {
                status = this._moneyKindAcs.Search(out workList, LoginInfoAcquisition.EnterpriseCode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (workList != null))
                {
                    retList = new SortedList();
                    foreach (MoneyKind moneyKind in workList)
                    {
                        // 指定された金額設定区分のみ格納
                        if (moneyKind.PriceStCode == priceStCode)
                        {
                            retList.Add(moneyKind.MoneyKindCode, moneyKind.Clone());
                            stc_depositKindSortList.Add(moneyKind.MoneyKindCode, moneyKind.Clone());
                        }
                    }
                }
                else
                {
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        default:
                            errMsg = "金額種別設定の読込に失敗しました";
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retList = new SortedList();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion
		#endregion ■ Private Method
	}
}
