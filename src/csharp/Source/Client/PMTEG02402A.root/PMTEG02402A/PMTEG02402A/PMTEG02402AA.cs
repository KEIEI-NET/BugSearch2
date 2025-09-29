//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表アクセスクラス
// プログラム概要   : 手形月別予定表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010.05.05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 修 正 日  2010.05.16  修正内容 : 障害対応 redmin#7598 一度手形種別を印字したら、手形種別が変更になるまで、印字は不要です
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 修 正 日  2010.06.29  修正内容 : 障害対応 redmin#10554手形月別予定表／仕様書の内容と印字内容が異なる
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 手形月別予定表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形月別予定表で使用するデータを取得する</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br>Update Note: 2010.05.16 姜凱 障害対応</br>
    /// <br>             redmin#7598 一度手形種別を印字したら、手形種別が変更になるまで、印字は不要です</br>
    /// </remarks>
    public class TegataTsukibetsuYoteListReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 手形月別予定表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 手形月別予定表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataTsukibetsuYoteListReportAcs()
		{
            this._iTegataTsukibetsuYoteListReportResultDB = (ITegataTsukibetsuYoteListReportResultDB)MediationTegataTsukibetsuYoteListReportResultDB.GetTegataTsukibetsuYoteListReportResultDB();
		}
        #endregion ■ Constructor

        #region ■ Private Member
        // 手形月別予定表検索インタフェース
        ITegataTsukibetsuYoteListReportResultDB _iTegataTsukibetsuYoteListReportResultDB;

        // DataSetオブジェクト
        private DataSet _dataSet;

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// データセット(読み取り専用)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 手形月別予定表データ取得
        /// <summary>
        /// 手形月別予定表データ取得
        /// </summary>
        /// <param name="tegataTorihikisakiListReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形月別予定表データを取得する。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataTsukibetsuYoteListReportProcMain(TegataTsukibetsuYoteListReport tegataTorihikisakiListReport, out string errMsg)
        {
            return this.SearchTegataTsukibetsuYoteListReportProcProc(tegataTorihikisakiListReport, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="tegataTorihikisakiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形月別予定表データを取得する。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataTsukibetsuYoteListReportProcProc(TegataTsukibetsuYoteListReport tegataTorihikisakiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02405EA.CreateDataTable(ref _dataSet);
                // 抽出条件展開  --------------------------------------------------------------
                TegataTsukibetsuYoteListReportParaWork tegataTorihikisakiListReportparaWork = new TegataTsukibetsuYoteListReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataTorihikisakiListReport, out tegataTorihikisakiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataTorihikisakiListReportparaWork;
                status = _iTegataTsukibetsuYoteListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02405EA.ct_Tbl_TegataTsukibetsuYoteListReportData], (ArrayList)retList, tegataTorihikisakiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02405EA.ct_Tbl_TegataTsukibetsuYoteListReportData].Rows.Count < 1)
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
                        errMsg = "手形月別予定表の帳票出力データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
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
        /// <param name="tegataTorihikisakiListReport">UI抽出条件クラス</param>
        /// <param name="tegataTorihikisakiListReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataTsukibetsuYoteListReport tegataTorihikisakiListReport, out TegataTsukibetsuYoteListReportParaWork tegataTorihikisakiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataTorihikisakiListReportParaWork = new TegataTsukibetsuYoteListReportParaWork();
            try
            {  
                // 企業コード
                tegataTorihikisakiListReportParaWork.EnterpriseCode = tegataTorihikisakiListReport.EnterpriseCode;

				// 手形区分
				tegataTorihikisakiListReportParaWork.DraftDivide = tegataTorihikisakiListReport.DraftDivide;

                // 印刷範囲年月
                tegataTorihikisakiListReportParaWork.SalesDate = tegataTorihikisakiListReport.SalesDate;

				// 改頁
				tegataTorihikisakiListReportParaWork.ChangePageDiv = tegataTorihikisakiListReport.ChangePageDiv;

				// ソート順
				tegataTorihikisakiListReportParaWork.SortOrder = tegataTorihikisakiListReport.SortOrder;

				// 銀行/支店開始
				tegataTorihikisakiListReportParaWork.BankAndBranchCdSt = tegataTorihikisakiListReport.BankAndBranchCdSt;

				// 銀行/支店終了
				tegataTorihikisakiListReportParaWork.BankAndBranchCdEd = tegataTorihikisakiListReport.BankAndBranchCdEd;

				// 手形種別
				if (tegataTorihikisakiListReport.DraftKindCds.Length != 0)
				{
					tegataTorihikisakiListReportParaWork.DraftKindCds = tegataTorihikisakiListReport.DraftKindCds;
				}
				else
				{
					tegataTorihikisakiListReportParaWork.DraftKindCds = null;
				}

				// 手形種別名称
				tegataTorihikisakiListReportParaWork.DraftKindCdsHt = tegataTorihikisakiListReport.DraftKindCdsHt;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 取得データ展開処理
        /// <summary>
        /// DataTableにデータを設定処理
        /// </summary>
        /// <param name="dataTable">帳票用DataTable</param>
        /// <param name="retList">検索情報リスト</param>
        /// <param name="paraWork">paraWork</param>
        /// <remarks>
		/// <br>Note       : DataTableにデータを設定処理を行う</br>
		/// <br>Programmer : 姜凱</br>
		/// <br>Date       : 2010.05.05</br>
		/// <br>Update Note: 2010.05.16 姜凱 一度手形種別を印字したら、手形種別が変更になるまで、印字は不要です</br>
		/// </remarks>
		private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataTsukibetsuYoteListReportParaWork paraWork)
		{
			// 手形種別+銀行支店
			string nextDraftKindCd_BankAndBranchCd = string.Empty;
			// --- ADD 2010/05/16 -------------->>>>>
			// 手形種別
			string nextDraftKindCd = string.Empty;
			// --- ADD 2010/05/16 --------------<<<<<
			// 指定月
            int month = 0;

            // （開始月分～６ヶ月目分）と６ヶ月以降の合計値
            long[] sumMonthGokei = new long[7];

            DataRow dr = null;
            TegataTsukibetsuYoteListReportResultWork rsltInfo = null;

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataTsukibetsuYoteListReportResultWork)retList[i];

				// 手形種別、銀行支店、有効期限で集計を行い印字する。
				if (!nextDraftKindCd_BankAndBranchCd.Equals(rsltInfo.DraftKindCd.ToString("D2")
							+ "|" + rsltInfo.BankAndBranchCd.ToString("D7")))
				{
					if (i != 0)
					{
						SetDataRow(ref dr, sumMonthGokei);
						dataTable.Rows.Add(dr);
					}
					nextDraftKindCd_BankAndBranchCd = rsltInfo.DraftKindCd.ToString("D2")
							+ "|" + rsltInfo.BankAndBranchCd.ToString("D7");
					dr = dataTable.NewRow();

					// 手形種別
					dr[PMTEG02405EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                    // --- DEL 2010.06.29 Redmine#10554 張義 ---------->>>>>
					// --- ADD 2010/05/16 -------------->>>>>
					// 出力順は手形種別順　且つ　手形種別不変の場合
                    //if ((paraWork.SortOrder == 0) && (nextDraftKindCd.Equals(rsltInfo.DraftKindCd.ToString("D2"))))
                    //{
                    //    // 手形種別名称
                    //    dr[PMTEG02405EA.ct_Col_DraftKindName] = string.Empty;
                    //}
                    //else
                    //{
                    //// --- ADD 2010/05/16 --------------<<<<<
                    //    // 手形種別名称
                    //    dr[PMTEG02405EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[rsltInfo.DraftKindCd];
                    //}	//  ADD 2010/05/16 
                    // --- DEL 2010.06.29 Redmine#10554 張義 ----------<<<<<
                    dr[PMTEG02405EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[rsltInfo.DraftKindCd]; //ADD 2010.06.29 Redmine#10554 張義
					// 銀行支店
					dr[PMTEG02405EA.ct_Col_BankAndBranchCd] = rsltInfo.BankAndBranchCd.ToString("D7").Substring(0, 4)
						+ "-" + rsltInfo.BankAndBranchCd.ToString("D7").Substring(4, 3);
					// 銀行支店名称
					dr[PMTEG02405EA.ct_Col_BankAndBranchNm] = rsltInfo.BankAndBranchNm;

					sumMonthGokei = new long[7];
					nextDraftKindCd = rsltInfo.DraftKindCd.ToString("D2"); //  ADD 2010/05/16 
				}

				// 開始月分
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == (this.DateTimeToLongDateYM(paraWork.SalesDate)).ToString())
                {
                    sumMonthGokei[0] += rsltInfo.Deposit;
                }
                // ２ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 1);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[1] += rsltInfo.Deposit;
                }
                // ３ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 2);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[2] += rsltInfo.Deposit;
                }
                // ４ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 3);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[3] += rsltInfo.Deposit; 
                }
                // ５ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 4);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[4] += rsltInfo.Deposit; 
                }
                // ６ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 5);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[5] += rsltInfo.Deposit; 
                }
                // ６ヶ月以降分
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6).CompareTo(month.ToString()) > 0)
                {
                    sumMonthGokei[6] += rsltInfo.Deposit;
                }

                // 最後のレコード
                if (i == retList.Count - 1)
                {
                    SetDataRow(ref dr, sumMonthGokei);
                    dataTable.Rows.Add(dr);
                }
            }
        }
        #endregion
        
        /// <summary>
        /// datarowの設定
        /// </summary>
        /// <param name="dr">行データ</param>
        /// <param name="sumMonthGokei">（開始月分～６ヶ月目分）と６ヶ月以降の合計値</param>
        /// <remarks>
        /// <br>Note       : datarowの設定を行う</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
		private void SetDataRow(ref DataRow dr, long[] sumMonthGokei)
		{
			// 開始月分の合計
			dr[PMTEG02405EA.ct_Col_SumMonth1] = sumMonthGokei[0];
			// ２ヶ月目分の合計
			dr[PMTEG02405EA.ct_Col_SumMonth2] = sumMonthGokei[1];
			// ３ヶ月目分の合計
			dr[PMTEG02405EA.ct_Col_SumMonth3] = sumMonthGokei[2];
			// ４ヶ月目分の合計
			dr[PMTEG02405EA.ct_Col_SumMonth4] = sumMonthGokei[3];
			// ５ヶ月目分の合計
			dr[PMTEG02405EA.ct_Col_SumMonth5] = sumMonthGokei[4];
			// ６ヶ月目分の合計
			dr[PMTEG02405EA.ct_Col_SumMonth6] = sumMonthGokei[5];
			// ６ヶ月以降分の合計
			dr[PMTEG02405EA.ct_Col_SumMonthSpare] = sumMonthGokei[6];
			// 合計
			dr[PMTEG02405EA.ct_Col_SumMonthAll] = sumMonthGokei[0] + sumMonthGokei[1] + sumMonthGokei[2] + sumMonthGokei[3] + sumMonthGokei[4] + sumMonthGokei[5] + sumMonthGokei[6];
		}

        /// <summary>
        /// LongDate DateTime 変換処理(YYYYMM)
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>LongDate(YYYYMM)</returns>
        /// <remarks>
        /// <br>Note       : DateTimeからLongDateに変換します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public int DateTimeToLongDateYM(DateTime dt)
        {
            return TDateTime.DateTimeToLongDate("YYYYMM", dt);
        }

        /// <summary>
        /// 年月計算処理
        /// </summary>
        /// <param name="yearMonth">計算前年月</param>
        /// <param name="monthes">加算(減算)月数</param>
        /// <returns>計算後年月</returns>
        /// <remarks>
        /// <br>Note       : 指定された月数を加算した年月を返します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public int CalculateYearMonth(int yearMonth, int monthes)
        {
            int resultYearMonth = 0;

            // 一旦月に変換
            int wkMonth = (yearMonth / 100) * 12 + (yearMonth % 100) - 1;

            // 加算(減算)月数を反映
            wkMonth += monthes;

            // 年月に戻す
            resultYearMonth = (wkMonth / 12) * 100 + wkMonth % 12 + 1;

            return resultYearMonth;
        }

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
